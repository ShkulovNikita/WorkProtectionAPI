using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WorkProtectionDataAccess;

namespace uirsWorkProtection.Controllers
{
    public class ChosenTestController : ApiController
    {
        public string Get(string id)
        {
            string result = "";

            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    entities.Database.CommandTimeout = 120;

                    //по идентификатору теста получаем информацию о нем
                    Guid ident = new Guid(id);

                    //получение имени и времени прохождения
                    var testData = entities.SurveyTemplateFullInfo.FirstOrDefault(e => e.Guid.ToString() == id);

                    string name = testData.Name;
                    int time;

                    if (testData.QuestionTime != null)
                    {
                        time = Convert.ToInt16(testData.QuestionTime);
                    }
                    else
                    {
                        time = 0;
                    }

                    //получение количеств категорий вопросов теста
                    var questionCategoryData = from questionCategory in entities.SurveyTemplateQuestionCategory
                                               where questionCategory.TemplateGuid.ToString() == id
                                               select questionCategory;

                    //общее число категорий
                    int n = questionCategoryData.Count();

                    //получение вопросов из категорий

                    List<int> nums = new List<int>();
                    List<int> categs = new List<int>();

                    List<Guid> idsOfQuestions = new List<Guid>();
                    List<string> questions = new List<string>();
                    List<string> typesOfQuestions = new List<string>();
                    List<string> namesOfFiles = new List<string>();

                    List<Guid> idsOfAnswers = new List<Guid>();

                    if (n == 1)
                    {
                        //получение количества вопросов и id категории
                        var numbCat = entities.SurveyTemplateQuestionCategory.FirstOrDefault(e => e.TemplateGuid.ToString() == id);
                        nums.Add(Convert.ToInt16(numbCat.QuestionCount));
                        categs.Add(Convert.ToInt16(numbCat.QuestionCategoryId));
                    }
                    else if (n > 1)
                    {
                        foreach (var quest in questionCategoryData)
                        {
                            nums.Add(Convert.ToInt16(quest.QuestionCount));
                            categs.Add(Convert.ToInt16(quest.QuestionCategoryId));
                        }
                    }

                    for (int g = 0; g < categs.Count; g++)
                    {
                        //получение всех вопросов из категории categ
                        int temp = categs[g];

                        var questionsData = from quesData in entities.QuestionInfo
                                            where quesData.CategoryId == temp
                                            select quesData;

                        //получение num первых вопросов из этой категории
                        int i = 0;
                        foreach (var quest in questionsData)
                        {
                            //запись идентификатора и текста вопроса
                            idsOfQuestions.Add(quest.Guid);

                            if (quest.Text != null)
                                questions.Add(quest.Text);
                            else questions.Add("null");

                            //определение типа вопроса
                            if ((quest.Image == null))
                            {
                                typesOfQuestions.Add("текст");
                            }
                            else
                            if (((quest.Image[quest.Image.Length - 3] == 'a') && (quest.Image[quest.Image.Length - 2] == 'v') && (quest.Image[quest.Image.Length - 1] == 'i'))
                                || ((quest.Image[quest.Image.Length - 3] == 'm') && (quest.Image[quest.Image.Length - 2] == 'p') && (quest.Image[quest.Image.Length - 1] == '4')))
                            {
                                typesOfQuestions.Add("видео");
                            }
                            else
                            {
                                typesOfQuestions.Add("изображение");
                            }

                            //добавление пути к файлу вопроса
                            if (quest.Image != null)
                            {
                                int numOfEnd = 0;
                                for (int j = 0; j< quest.Image.Length;j++)
                                {
                                    if (quest.Image[j] == ';')
                                    {
                                        numOfEnd = j;
                                        break;
                                    }
                                }
                                string nameOfFile = quest.Image.Substring(0, numOfEnd);

                                namesOfFiles.Add(nameOfFile);
                            }
                            else
                            {
                                namesOfFiles.Add("_");
                            }

                            i++;
                            if (i == nums[g])
                                break;
                        }
                    }

                    //получение вариантов ответов для вопросов
                    List<int> numberOfAnswers = new List<int>();
                    List<string> answers = new List<string>();
                    List<int> answersCorrectness = new List<int>();

                    //проход по всем найденным вопросам
                    for (int i = 0; i < idsOfQuestions.Count; i++)
                    {
                        Guid temp = idsOfQuestions[i];

                        var questionAnswerData = entities.QuestionAnswerInfo.Where(e => e.QuestionGuid == temp);

                        numberOfAnswers.Add(questionAnswerData.Count());

                        foreach (var questAnsw in questionAnswerData)
                        {
                            string answ = questAnsw.Name;
                            answ = answ.Replace("\"", "");
                            answers.Add(answ);
                            string correctness = questAnsw.Correct;
                            if (correctness != null)
                            {
                                correctness = correctness.Replace("%", "");
                                answersCorrectness.Add(Convert.ToInt16(correctness));
                            }
                            else
                            {
                                answersCorrectness.Add(0);
                            }
                        }
                    }

                    //создание объекта для отправки
                    ChosenTestInfo chosenTestInfo = new ChosenTestInfo(ident, name, time, questions.ToArray(), 
                                                                       typesOfQuestions.ToArray(), namesOfFiles.ToArray(), 
                                                                       numberOfAnswers.ToArray(), answers.ToArray(), 
                                                                       answersCorrectness.ToArray());

                    result = JsonConvert.SerializeObject(chosenTestInfo);
                }
            }
            catch (Exception ex)
            {
                result = "Произошла ошибка";
            }

            return result;
        }
    }
}

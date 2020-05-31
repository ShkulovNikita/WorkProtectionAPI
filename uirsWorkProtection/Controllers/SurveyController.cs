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
    public class SurveyController : ApiController
    {
        public string Get(string id)
        {
            string result = "";

            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    //получение списка тестов по id пользователя
                    var testData = from test in entities.SurveyTemplateFullInfo
                                   join testUser in entities.SurveyTemplatePatientInfo on test.Guid equals testUser.TemplateGuid
                                   where testUser.PatientGuid.ToString() == id
                                   select test;

                    if (!testData.Any())
                    {
                        result = "Ничего не найдено";
                    }
                    else
                    {
                        int n = testData.Count();

                        //массивы для передачи объекту теста
                        Guid[] ids = new Guid[n];
                        string[] names = new string[n];
                        string[] expireDates = new string[n];
                        bool[] passed = new bool[n];

                        //заполнение массивов и получение оставшихся полей
                        int i = 0;
                        foreach(var test in testData)
                        {
                            ids[i] = test.Guid;
                            names[i] = test.Name;

                            //обработка оставшегося времени
                            {
                                try
                                {
                                    if ((test.Type.ToLower() == "ежедневная")||(test.Type.ToLower() == "плановая"))
                                    {
                                        expireDates[i] = DateTime.Today.ToString();
                                    }
                                    else if (test.Type.ToLower() == "еженедельная")
                                    {
                                        //получение последнего дня текущей недели
                                        DateTime baseDate = DateTime.Now;
                                        var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                                        var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

                                        expireDates[i] = thisWeekEnd.ToString();
                                    }
                                    else if (test.Type.ToLower() == "ежемесячная")
                                    {
                                        string baseDate = DateTime.Now.ToString();
                                        int currentYear = DateTime.Parse(baseDate).Year;
                                        int currentMonth = DateTime.Parse(baseDate).Month;
                                        DateTime endOfMonth = new DateTime(currentYear, currentMonth,
                                                                           DateTime.DaysInMonth(currentYear, currentMonth));

                                        expireDates[i] = endOfMonth.ToString();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    expireDates[i] = DateTime.Today.ToString();
                                }
                            }

                            passed[i] = false;

                            i++;
                        }

                        TestInfo testInfo = new TestInfo(ids, names, expireDates, passed);
                        result = JsonConvert.SerializeObject(testInfo);
                    }
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

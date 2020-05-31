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
    public class BriefingsController : ApiController
    {
        public string Get (string id)
        {
            string result = "";

            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    //получение профессии пользователя по его id
                    var userData = entities.PatientTable.FirstOrDefault(e => e.Guid.ToString() == id);
                    string profession = userData.Profession;

                    //получение инструкций по профессии
                    var instructions = from inst in entities.InstructionProfession
                                       join pr in entities.Post on inst.ProfessionId equals pr.ID
                                       where pr.Name == profession
                                       select inst;

                    int count = instructions.Count();

                    //создание массивов для отправки клиенту
                    Guid[] ids = new Guid[count];
                    string[] names = new string[count];
                    string[] expireDates = new string[count];
                    string[] files = new string[count];
                    bool[] passed = new bool[count];

                    int counter = 0;
                    //получение с использованием Guid описаний инструкций
                    foreach (var instr in instructions)
                    {
                        //получение описания инструктажа
                        var description = entities.InstructionInfo.FirstOrDefault(e => e.Guid == instr.InstructionGuid);
                        ids[counter] = description.Guid;
                        names[counter] = description.Name;
                        expireDates[counter] = description.Date.ToString();

                        //получение пути до файла
                        var fileOfBriefing = entities.InstructionFile.FirstOrDefault(e => e.InstructionGuid == instr.InstructionGuid);
                        var pathOfFile = entities.AttachedFile.FirstOrDefault(e => e.Guid == fileOfBriefing.FileGuid);
                        if ((pathOfFile.Path != null) && (pathOfFile.Path != "")) 
                        {
                            string fileNm = pathOfFile.Name;
                            fileNm = fileNm.Replace(".pdf", "");
                            files[counter] = fileNm;
                        }
                        else
                        {
                            files[counter] = "null";
                        }

                        Guid temp = ids[counter];

                        //проверка, был ли инструктаж уже пройден
                        var passing = from pass in entities.Briefing
                                      where (pass.PatientGuid.ToString() == id)
                                      && (pass.InstructionGuid == temp)
                                      select pass;

                        if (!passing.Any())
                        {
                            passed[counter] = false;
                        }
                        else
                        {
                            passed[counter] = true;
                        }

                        //переход к следующему найденному инструктажу
                        counter++;
                    }

                    if(!instructions.Any())
                    {
                        result = "Ничего не найдено";
                    }
                    else
                    {
                        //создание объекта для отправки
                        BriefingInfo briefingInfo = new BriefingInfo(ids, names, expireDates, files, passed);
                        result = JsonConvert.SerializeObject(briefingInfo);
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

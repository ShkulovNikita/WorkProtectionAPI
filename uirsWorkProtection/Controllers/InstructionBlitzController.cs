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
    public class InstructionBlitzController : ApiController
    {
        public string Get()
        {
            string result = "";

            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    //получение списка памяток
                    var instructionData = from instr in entities.InstructionBlitzInfo
                                          orderby instr.Date descending
                                          select instr;

                    //количество последних n инструкций, отправляемых пользователю
                    int n = 5;

                    //массивы с данными для передачи объекту
                    Guid[] ids = new Guid[n];
                    string[] names = new string[n];
                    string[] dates = new string[n];
                    string[] files = new string[n];

                    //заполнение массивов полученными данными
                    int i = 0;
                    foreach (var instr in instructionData)
                    {
                        ids[i] = instr.Guid;
                        names[i] = instr.Name;
                        dates[i] = instr.Date.ToString();

                        Guid temp = ids[i];

                        //получение файла для памятки
                        var fileId = entities.InstructionBlitzFile.FirstOrDefault(e => e.InstructionBlitzGuid == temp);
                        if (fileId != null)
                        {
                            var filePath = entities.AttachedFile.FirstOrDefault(e => e.Guid == fileId.FileGuid);
                            string nameOfFile = filePath.Path.Replace("\\InstructionBlitzs\\", "");
                            files[i] = nameOfFile;
                        }
                        else
                        {
                            files[i] = "null";
                        }

                        i++;
                        if (i == n)
                            break;
                    }

                    if (!instructionData.Any())
                    {
                        result = "Ничего не найдено";
                    }
                    else
                    {
                        InstructionBlitzInfo instructionBlitzInfo = new InstructionBlitzInfo(ids, names, dates, files);
                        result = JsonConvert.SerializeObject(instructionBlitzInfo);
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
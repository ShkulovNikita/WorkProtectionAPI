using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkProtectionDataAccess;

namespace uirsWorkProtection.Controllers
{
    public class GetBriefingResultController : ApiController
    {
        [HttpPost]
        public string Briefing(HttpRequestMessage message)
        {
            try
            {
                var msg = message.Content.ReadAsStringAsync().Result;

                var date = JObject.Parse(msg)["Date"];
                var patientGuid = JObject.Parse(msg)["UserGuid"];
                var instructuonGuid = JObject.Parse(msg)["InstructionGuid"];
                var statusId = JObject.Parse(msg)["StatusId"];
                var timeSeconds = JObject.Parse(msg)["TimeSeconds"];
                var instructionType = JObject.Parse(msg)["InstructionType"];
                var deviceGuid = JObject.Parse(msg)["DeviceGuid"];

                DateTime dateOfBrief = Convert.ToDateTime(date);
                Guid patient = new Guid(patientGuid.ToString());
                Guid instruction = new Guid(instructuonGuid.ToString());
                int status = Convert.ToInt16(statusId);
                int time = Convert.ToInt16(timeSeconds);
                int type = Convert.ToInt16(instructionType);
                Guid device = new Guid(deviceGuid.ToString());

                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    //получение текущего максимального идентификатора
                    int num = (from brief in entities.Briefing
                               orderby brief.Id descending
                               select brief.Id).First();

                    num++;

                    //создание новой записи в БД
                    Briefing briefing = new Briefing();
                    briefing.Id = num;
                    briefing.InstructionGuid = instruction;
                    briefing.InstructionType = type;
                    briefing.PatientGuid = patient;
                    briefing.StatusId = status;
                    briefing.TimeSeconds = time;
                    briefing.Date = dateOfBrief;
                    briefing.DeviceGuid = device;

                    entities.Briefing.Add(briefing);
                    entities.SaveChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}

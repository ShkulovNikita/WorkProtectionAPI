using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace uirsWorkProtection.Controllers
{
    public class GetTestResultController : ApiController
    {
        [HttpPost]
        public string Test(HttpRequestMessage message)
        {
            try
            {
                //получение POST-сообщения
                var msg = message.Content.ReadAsStringAsync().Result;
            
                //получение полей из JSON
                var date = JObject.Parse(msg)["Date"];
                var userGuid = JObject.Parse(msg)["UserGuid"];
                var testGuid = JObject.Parse(msg)["TestGuid"];
                var elapsedTime = JObject.Parse(msg)["ElapsedTime"];
                var deviceGuid = JObject.Parse(msg)["DeviceGuid"];

                DateTime dateOfTest = Convert.ToDateTime(date);
                Guid user = new Guid(userGuid.ToString());
                Guid test = new Guid(testGuid.ToString());
                int time = Convert.ToInt16(elapsedTime);
                Guid device = new Guid(deviceGuid.ToString());

                //получение процентов правильности ответов
                var correctness = JObject.Parse(msg)["Correctness"];
                var correctPercents = JObject.Parse(correctness.ToString())["correctPercents"];

                int[] correct = new int[correctPercents.Count()];
                for (int i = 0; i < correctPercents.Count(); i++)
                {
                    correct[i] = Convert.ToInt16(correctPercents[i]);
                }

                //сохранение в БД
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}

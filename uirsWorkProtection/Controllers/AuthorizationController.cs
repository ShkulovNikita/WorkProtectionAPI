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
    public class AuthorizationController : ApiController
    {
        public string Get(string id)
        {
            string result = "";

            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    var userData = entities.PatientTable.FirstOrDefault(e => e.JobTabNumber == id);
                    Guid ident = userData.Guid;
                    string surname = userData.LastName;
                    string name = userData.FirstName;
                    string patronymic = userData.MiddleName;
                    string profession = userData.Profession;
                    if (String.IsNullOrEmpty(profession))
                    {
                        result = "Пользователь не найден";
                    }
                    else
                    {
                        UserInfo userInfo = new UserInfo(ident, surname, name, patronymic, profession);
                        result = JsonConvert.SerializeObject(userInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                result = "Пользователь не найден";
            }

            return result;
        }

    }
}

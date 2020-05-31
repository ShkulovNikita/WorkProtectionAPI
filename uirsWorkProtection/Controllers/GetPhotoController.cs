using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WorkProtectionDataAccess;

namespace uirsWorkProtection.Controllers
{
    public class GetPhotoController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            string userPhoto;
            try
            {
                using (WorkProtectionEntities entities = new WorkProtectionEntities())
                {
                    var photoOfUser = entities.PatientPhoto.FirstOrDefault(e => e.PatientGuid.ToString() == id);
                    if (photoOfUser != null)
                        userPhoto = photoOfUser.SrcOriginal;
                    else userPhoto = "default.png";
                }
            } catch (Exception ex)
            {
                userPhoto = "error";
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            string fileName = userPhoto;

            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/Photos/");

            if(!File.Exists(filePath + fileName))
            {
                fileName = "default.png";
            }

            filePath = filePath + fileName;

            ImageLoader imageLoader = new ImageLoader(filePath, fileName, response);

            return imageLoader.ConvertToBytes();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace uirsWorkProtection.Controllers
{
    public class GetTestFileController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            string fileName = id;

            fileName = fileName.Replace("prob", " ");
            fileName = fileName.Replace("pnt", ".");

            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/Tests/");

            filePath = filePath + fileName;

            ImageLoader imageLoader = new ImageLoader(filePath, fileName, response);

            return imageLoader.ConvertToBytes();
        }
    }
}

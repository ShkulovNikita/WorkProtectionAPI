using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace uirsWorkProtection.Controllers
{
    public class GetBriefingFileController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            
            string fileName = id + ".pdf";

            fileName = fileName.Replace("prob", " ");
            fileName = fileName.Replace("pnt", ".");

            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/Instructions/" + fileName);

            ImageLoader imageLoader = new ImageLoader(filePath, fileName, response);

            return imageLoader.ConvertToBytes();
        }
    }
}

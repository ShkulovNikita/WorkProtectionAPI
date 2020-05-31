using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace uirsWorkProtection.Controllers
{
    public class GetInstructionBlitzFileController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            string fileName = id + ".pdf";

            fileName = fileName.Replace("prob", " ");
            fileName = fileName.Replace("pnt", ".");

            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/InstructionBlitzs/" + fileName);

            ImageLoader imageLoader = new ImageLoader(filePath, fileName, response);

            return imageLoader.ConvertToBytes();
        }
    }
}

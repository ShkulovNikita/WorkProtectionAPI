using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace uirsWorkProtection
{
    public class ImageLoader
    {
        private string FileName { get; set; }
        private string FilePath { get; set; }
        public HttpResponseMessage Response { get; set; }

        public ImageLoader(string filepath, string filename, HttpResponseMessage response)
        {
            FilePath = filepath;
            FileName = filename;
            Response = response;
        }

        public HttpResponseMessage ConvertToBytes()
        {
            //Read the File into a Byte Array.
            byte[] bytes = File.ReadAllBytes(FilePath);

            //Set the Response Content.
            Response.Content = new ByteArrayContent(bytes);

            //Set the Response Content Length.
            Response.Content.Headers.ContentLength = bytes.LongLength;

            //Set the Content Disposition Header Value and FileName.
            Response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            Response.Content.Headers.ContentDisposition.FileName = FileName;

            //Set the File Content Type.
            Response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(FileName));

            return Response;
        }
    }
}
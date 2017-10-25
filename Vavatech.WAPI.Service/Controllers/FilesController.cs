using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.Service.ActionResults;

namespace Vavatech.WAPI.Service.Controllers
{
    public class FilesController : ApiController
    {

        [Route("api/files/{filename}")]
        public IHttpActionResult Get(string filename)
        {
            var basedir = @"C:\temp";

            var path = Path.Combine(basedir, filename);

            Stream stream = new FileStream(path, FileMode.Open);

            return new StreamActionResult(stream, "application/octet-stream");
        }
    }
}
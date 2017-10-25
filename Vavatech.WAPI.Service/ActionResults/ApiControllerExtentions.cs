using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Vavatech.WAPI.Service.ActionResults
{
    public static class ApiControllerExtentions
    {
        public static IHttpActionResult MyResult(this ApiController controller)
        {
            return new CustomActionResult();
        }

        public static IHttpActionResult HtmlResult(this ApiController controller, string html)
        {
            return new HtmlActionResult(html);
        }
    }
}
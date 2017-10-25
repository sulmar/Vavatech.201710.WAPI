using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Vavatech.WAPI.Service.ActionResults
{
    public class HtmlActionResult : IHttpActionResult
    {
        private string html;

        public HtmlActionResult(string html)
        {
            this.html = html;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            response.Content = new StringContent(html, null, "text/html");

            return Task.FromResult(response);


        }
    }
}
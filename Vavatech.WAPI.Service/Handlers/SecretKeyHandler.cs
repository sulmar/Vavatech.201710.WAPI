using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Vavatech.WAPI.Service.Extensions;

namespace Vavatech.WAPI.Service.Handlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsValid(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

                return response;
            }
        }

        private bool IsValid(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("secret-key", out IEnumerable<string> secretkeys))
            {
                var secretkey = secretkeys.First();

                return secretkey == "1234";
            }

            return false;
        }
    }
}
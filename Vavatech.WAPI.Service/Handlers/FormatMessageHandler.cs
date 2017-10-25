﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class FormatMessageHandler : DelegatingHandler
    {
        private const string keyword = "format";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.GetQueryNameValuePairs();

            var parameter = parameters.FirstOrDefault(p => p.Key == keyword);

            if (parameter.Value != null)
            {
                request.Headers.Add("Accept", parameter.Value);

            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}
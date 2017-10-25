﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    //http://localhost:64688/api/users/12.png
    public class ExtensionMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uri = request.RequestUri;

            if (System.IO.Path.HasExtension(uri.ToString()))
            {

            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
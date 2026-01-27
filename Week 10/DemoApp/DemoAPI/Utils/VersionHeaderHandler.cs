using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace DemoAPI.Utils
{
    public class VersionHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("X-Api-Version"))
            {
                var version = request.Headers.GetValues("X-Api-Version").FirstOrDefault();
                request.Properties["ApiVersion"] = version;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
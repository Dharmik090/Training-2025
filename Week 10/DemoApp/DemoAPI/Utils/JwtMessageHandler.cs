using System;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace DemoAPI.Utils
{

    public class JwtMessageHandler : DelegatingHandler
    {
        private readonly TokenValidationParameters _validationParameters;

        public JwtMessageHandler()
        {
             var key = Encoding.UTF8.GetBytes("some_very_long_secret_key_1234567");

            _validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var authHeader = request.Headers.Authorization;
            //if (authHeader != null && authHeader.Scheme == "Bearer")
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    try
            //    {
            //        var principal = tokenHandler.ValidateToken(authHeader.Parameter, _validationParameters, out _);
            //        Thread.CurrentPrincipal = principal;
            //        if (HttpContext.Current != null)
            //            HttpContext.Current.User = principal;
            //    }
            //    catch (Exception)
            //    {
            //        return request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid or expired token." });
            //    }
            //}

            if (request.Headers.Contains("api_key")) 
            { 
                var token = request.Headers.GetValues("api_key").FirstOrDefault(); 
                var tokenHandler = new JwtSecurityTokenHandler(); 
                
                try { 
                    var principal = tokenHandler.ValidateToken(token, _validationParameters, out _); 
                    Thread.CurrentPrincipal = principal; 
                    
                    if (HttpContext.Current != null) 
                        HttpContext.Current.User = principal; 
                } 
                catch (Exception) 
                { 
                    return request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid or expired token." }); 
                } 
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
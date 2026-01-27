using DemoAPI.Authentication;
using DemoAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (request.Username == "rkit" && request.Password == "Miracle@123")
            {
                string token = JwtTokenHelper.GenerateToken(request.Username, "Admin");
                return Ok(new { token, type = "jwt" });
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("google")] 
        public IHttpActionResult GoogleLogin() 
        { 
            string clientId = ConfigurationManager.AppSettings["ClientId"]; 
            
            string redirectUri = "https://localhost:44377/api/auth/google/callback"; 
            string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth"; 
            
            string scopes = "openid email profile"; 
            string url = $"{authorizationEndpoint}?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope={scopes}"; 
            
            return Redirect(url); 
        }

        [HttpGet]
        [Route("google/callback")]
        public async Task<IHttpActionResult> GoogleCallback(string code)
        {
            string clientId = ConfigurationManager.AppSettings["ClientId"]; string clientSecret = ConfigurationManager.AppSettings["ClientSecret"]; string redirectUri = "https://localhost:44377/api/auth/google/callback"; using (var client = new HttpClient())
            {
                var tokenResponse = await client.PostAsync("https://oauth2.googleapis.com/token", new FormUrlEncodedContent(new Dictionary<string, string> { { "code", code }, { "client_id", clientId }, { "client_secret", clientSecret }, { "redirect_uri", redirectUri }, { "grant_type", "authorization_code" } })); 
                string json = await tokenResponse.Content.ReadAsStringAsync(); 
                
                var tokenData = JObject.Parse(json); 
                
                string accessToken = tokenData["access_token"].ToString(); // Fetch user profile
                
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken); 
                
                var profileResponse = await client.GetStringAsync("https://www.googleapis.com/oauth2/v3/userinfo"); 
                
                var profile = JObject.Parse(profileResponse); // Optionally issue your own JWT
                
                string jwtToken = JwtTokenHelper.GenerateToken((string)profile["email"], "GoogleUser"); 
                return Ok(new { profile, jwtToken }); 
            } 
        }    
    }
}

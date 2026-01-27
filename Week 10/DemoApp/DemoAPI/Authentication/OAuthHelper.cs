using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.Authentication
{
    public static class OAuthHelper
    {
        public static async Task<string> AuthenticateWithGoogle()
        {
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];

            ClientSecrets secrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            string[] scopes = { "openid", "email", "profile" };

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                scopes,
                "user",
                CancellationToken.None,
                new FileDataStore("OAuthDemoTokens", true)
            );

            return credential.Token.AccessToken;
        }

        public static async Task<JObject> GetUserProfile(string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response =
                    await client.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");

                string json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json);
            }
        }
    }
}

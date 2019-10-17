using System;
using RestSharp;
using RestSharp.Authenticators;

namespace Salesforce.MarketingCloud.Authentication
{
    public class ServerToServerOAuth2Authenticator : IAuthenticator
    {
        private readonly IAuthService authService;

        public ServerToServerOAuth2Authenticator(IAuthService authService)
        {
            this.authService = authService;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            var (restInstanceUrl, accessToken, expiresIn) = this.authService.GetToken();

            client.BaseUrl = new Uri(restInstanceUrl);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
        }
    }
}
using RestSharp;
using RestSharp.Authenticators;

namespace Salesforce.MarketingCloud.Authentication
{
    public class ServerToServerOAuth2Authenticator : IAuthenticator
    {
        private readonly IAuthService authService;

//        public ServerToServerOAuth2Authenticator()
//        {
//            
//        }

        public ServerToServerOAuth2Authenticator(IAuthService authService)
        {
            this.authService = authService;
        }

        public virtual void Authenticate(IRestClient client, IRestRequest request)
        {
            var token = this.authService.GetToken();

            request.AddHeader("Authorization", $"Bearer {token}");
        }
    }
}
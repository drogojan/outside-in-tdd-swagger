using NSubstitute;
using NUnit.Framework;
using RestSharp;
using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    public class ServerToServerOAuth2AuthenticatorShould
    {
        private string AUTH_URL = "https://auth.salesforce.com";
        private string CLIENT_ID = "client_id";
        private string CLIENT_SECRET = "client_secret";
        private string ACCOUNT_ID = "123456";

        [Test]
        public void Get_An_Access_Token()
        {
            IAuthService authService = Substitute.For<IAuthService>();

//            ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            var sut = new ServerToServerOAuth2Authenticator(authService);
            sut.Authenticate(Substitute.For<IRestClient>(), Substitute.For<IRestRequest>());

            authService.Received(1).GetToken();
        }

        [Test]
        public void Sets_The_Access_Token()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            authServiceStub.GetToken().Returns("auth token");

            //ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            var sut = new ServerToServerOAuth2Authenticator(authServiceStub);
            var restRequestMock = Substitute.For<IRestRequest>();
            sut.Authenticate(Substitute.For<IRestClient>(), restRequestMock);

            restRequestMock.Received(1).AddHeader("Authorization", "Bearer auth token");
        }
    }
}
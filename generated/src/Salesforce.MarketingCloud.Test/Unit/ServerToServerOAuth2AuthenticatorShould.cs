using System;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    public class ServerToServerOAuth2AuthenticatorShould
    {
        [Test]
        public void Set_The_Access_Token_In_The_Header()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            var token = (RestInstanceUrl: "https://abc.rest.marketingcloudapis.com/", AccessToken: "auth token");
            authServiceStub.GetToken().Returns(token);

            var sut = new ServerToServerOAuth2Authenticator(authServiceStub);
            var restRequestMock = Substitute.For<IRestRequest>();
            sut.Authenticate(Substitute.For<IRestClient>(), restRequestMock);

            restRequestMock.Received(1).AddHeader("Authorization", "Bearer auth token");
        }

        [Test]
        public void Set_The_Base_Url_For_The_Client()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            var token = (RestInstanceUrl: "https://abc.rest.marketingcloudapis.com/", AccessToken: "auth token");
            authServiceStub.GetToken().Returns(token);

            var sut = new ServerToServerOAuth2Authenticator(authServiceStub);
            var restClientMock = Substitute.For<IRestClient>();
            sut.Authenticate(restClientMock, Substitute.For<IRestRequest>());

            restClientMock.Received().BaseUrl = new Uri(token.RestInstanceUrl);
        }
    }
}
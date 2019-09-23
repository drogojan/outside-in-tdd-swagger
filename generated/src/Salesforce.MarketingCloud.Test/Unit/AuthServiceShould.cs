using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using Salesforce.MarketingCloud.Authentication;
using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    public class AuthServiceShould
    {
        private string AUTH_URL = "https://auth.salesforce.com";
        private string CLIENT_ID = "client_id";
        private string CLIENT_SECRET = "client_secret";
        private string ACCOUNT_ID = "123456";
        private string ACCESS_TOKEN = "token";
        private string REST_INSTANCE_URL = "https://rest.salesforce.com";

        [Test]
        public void Set_The_BaseUrl_On_The_RestClient()
        {
            IRestClient restClientMock = Substitute.For<IRestClient>();

            IRestResponse restResponseStub = Substitute.For<IRestResponse>();
            JsonObject tokenResponseJson = new JsonObject();
            tokenResponseJson.Add("rest_instance_url", REST_INSTANCE_URL);
            tokenResponseJson.Add("access_token", ACCESS_TOKEN);
            restResponseStub.Content = tokenResponseJson.ToString();

            restClientMock.Execute(Arg.Any<IRestRequest>()).Returns(restResponseStub);

            ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            AuthService sut = new AuthService(restClientMock, CLIENT_CONFIG);
            sut.GetToken();

            restClientMock.Received().BaseUrl = new Uri(CLIENT_CONFIG.AuthUrl);
        }

        [Test]
        public void Call_The_Token_Api_To_Get_A_Token()
        {
            IRestClient restClientMock = Substitute.For<IRestClient>();

            IRestResponse restResponseStub = Substitute.For<IRestResponse>();
            JsonObject tokenResponseJson = new JsonObject();
            tokenResponseJson.Add("rest_instance_url", REST_INSTANCE_URL);
            tokenResponseJson.Add("access_token", ACCESS_TOKEN);
            restResponseStub.Content = tokenResponseJson.ToString();

            restClientMock.Execute(Arg.Any<IRestRequest>()).Returns(restResponseStub);

            ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            AuthService sut = new AuthService(restClientMock, CLIENT_CONFIG);
            sut.GetToken();

            restClientMock.Received(1).Execute(Arg.Is<RestRequest>(
                req => req.Resource == "v2/token"
                       && req.Method == Method.POST
                       && req.RequestFormat == DataFormat.Json
                       && req.Parameters.Exists(
                           p => p.Type == ParameterType.RequestBody
                                && p.Value.ToString().Equals(TokenRequestPayloadFrom(CLIENT_CONFIG))
                       )
            ));
        }

        [Test]
        public void Return_The_Token_Information_From_The_Token_Api()
        {
            IRestClient restClientMock = Substitute.For<IRestClient>();

            IRestResponse restResponseStub = Substitute.For<IRestResponse>();
            JsonObject tokenResponseJson = new JsonObject
            {
                {"rest_instance_url", REST_INSTANCE_URL}, {"access_token", ACCESS_TOKEN}
            };
            restResponseStub.Content = tokenResponseJson.ToString();

            restClientMock.Execute(Arg.Any<IRestRequest>()).Returns(restResponseStub);

            ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            AuthService sut = new AuthService(restClientMock, CLIENT_CONFIG);

            (string RestInstanceUrl, string AccessToken) token = sut.GetToken();

            Assert.AreEqual(ACCESS_TOKEN, token.AccessToken);
            Assert.AreEqual(REST_INSTANCE_URL, token.RestInstanceUrl);
        }

        private string TokenRequestPayloadFrom(ClientConfig clientConfig)
        {
            var json = new JsonObject();
            json.Add("client_id", clientConfig.ClientId);
            json.Add("client_secret", clientConfig.ClientSecret);
            json.Add("account_id", clientConfig.AccountId);
            json.Add("grant_type", "client_credentials");

            return json.ToString();
        }
    }
}
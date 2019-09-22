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

        [Test]
        public void Call_The_Token_Api_To_Get_A_Token()
        {
            IRestClient restClientMock = Substitute.For<IRestClient>();

            ClientConfig CLIENT_CONFIG = new ClientConfig(AUTH_URL, CLIENT_ID, CLIENT_SECRET, ACCOUNT_ID);
            AuthService sut = new AuthService(restClientMock, CLIENT_CONFIG);
            sut.GetToken();

            restClientMock.Received().BaseUrl = new Uri(CLIENT_CONFIG.AuthUrl);
            restClientMock.Received(1).Execute<(string access_token, string rest_instance_url)>(Arg.Is<RestRequest>(
                req =>
                    req.Resource == "v2/token"
                    && req.Method == Method.POST
                    && req.RequestFormat == DataFormat.Json
                    && req.Parameters.Exists(
                        p => p.Type == ParameterType.RequestBody 
                             //&& p.Value.Equals(TokenRequestPayloadFrom(CLIENT_CONFIG))
                        )
            ));
        }

//        private TokenRequestPayload TokenRequestPayloadFrom(ClientConfig clientConfig)
//        {
//            throw new NotImplementedException();
//        }
    }
}
using NSubstitute;
using NUnit.Framework;
using Salesforce.MarketingCloud.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    class CachingAuthServiceShould
    {
        private string CLIENT_ID = "clientId";
        private string ACCOUNT_ID = "123456";
        private string REST_INSTANCE_URL = "https://rest.salesforce.com";
        private string ACCESS_TOKEN = "token";
        private int EXPIRES_IN = 1000;

        [Test]
        public void Try_To_Get_A_Token_From_Cache()
        {
            ICache cacheMock = Substitute.For<ICache>();
            IAuthService authServiceStub = Substitute.For<IAuthService>();

            (string ClienId, string AccountId) tuple = (CLIENT_ID, ACCOUNT_ID);
            CachingAuthService sut = new CachingAuthService(authServiceStub, cacheMock, tuple);

            sut.GetToken();

            cacheMock.Received(1).Get(CLIENT_ID + "-" + ACCOUNT_ID);
        }

        [Test]
        public void Call_The_Token_Api_On_A_Cache_Miss()
        {
            ICache cacheStub = Substitute.For<ICache>();
            cacheStub.Get(CLIENT_ID + "-" + ACCOUNT_ID).Returns<(string RestInstanceUrl, string AccessToken, int ExpiresIn)?>(((string RestInstanceUrl, string AccessToken, int ExpiresIn)?)null);
            IAuthService authServiceMock = Substitute.For<IAuthService>();

            (string ClienId, string AccountId) tuple = (CLIENT_ID, ACCOUNT_ID);
            CachingAuthService sut = new CachingAuthService(authServiceMock, cacheStub, tuple);

            sut.GetToken();

            authServiceMock.Received(1).GetToken();
        }

        [Test]
        public void Store_In_Cache_A_Token_Retrieved_From_The_Token_Api()
        {
            ICache cacheMock = Substitute.For<ICache>();
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            (string REST_INSTANCE_URL, string ACCESS_TOKEN, int EXPIRES_IN) token = (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN);
            authServiceStub.GetToken().Returns(token);

            (string ClienId, string AccountId) tuple = (CLIENT_ID, ACCOUNT_ID);
            CachingAuthService sut = new CachingAuthService(authServiceStub, cacheMock, tuple);

            sut.GetToken();

            cacheMock.Received(1).Add(CLIENT_ID + "-" + ACCOUNT_ID, token);
        }

        [Test]
        public void Return_The_Token()
        {
            ICache cacheStub = Substitute.For<ICache>();
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            (string REST_INSTANCE_URL, string ACCESS_TOKEN, int EXPIRES_IN) token = (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN);
            authServiceStub.GetToken().Returns(token);

            (string ClienId, string AccountId) tuple = (CLIENT_ID, ACCOUNT_ID);
            CachingAuthService sut = new CachingAuthService(authServiceStub, cacheStub, tuple);

            var actualToken = sut.GetToken();

            Assert.AreEqual(ACCESS_TOKEN, actualToken.AccessToken);
            Assert.AreEqual(REST_INSTANCE_URL, actualToken.RestInstanceUrl);
        }

        [Test]
        public void Not_Call_AuthService_When_Cached_Value_Exists()
        {
            ICache cacheStub = Substitute.For<ICache>();
            (string RestInstaceUrl, string AccessToken, int ExpiresIn) cachedValue = (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN);
            cacheStub.Get(CLIENT_ID + "-" + ACCOUNT_ID).Returns(cachedValue);

            IAuthService authServiceMock = Substitute.For<IAuthService>();

            (string ClienId, string AccountId) tuple = (CLIENT_ID, ACCOUNT_ID);
            CachingAuthService sut = new CachingAuthService(authServiceMock, cacheStub, tuple);

            var actualToken = sut.GetToken();

            authServiceMock.DidNotReceive().GetToken();
        }
    }
}

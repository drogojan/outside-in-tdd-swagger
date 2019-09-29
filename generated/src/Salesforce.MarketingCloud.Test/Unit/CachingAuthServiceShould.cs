using NSubstitute;
using NUnit.Framework;
using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    public class CachingAuthServiceShould
    {
        private string CLIENT_ID = "CLIENT_ID";
        private string ACCOUNT_ID = "123456";
        private string REST_INSTANCE_URL = "https://rest.salesforce.com";
        private string ACCESS_TOKEN = "access_token";
        private int EXPIRES_IN = 1200;

        [Test]
        public void Search_For_A_Cached_Value_By_ClientId_And_AccountId()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            ICache cacheMock = Substitute.For<ICache>();
            (string ClientId, string AccountId) cacheKeyComponents = (ClientId: CLIENT_ID, AccountId: ACCOUNT_ID);
            var sut = new CachingAuthService(authServiceStub, cacheMock, cacheKeyComponents);

            sut.GetToken();

            cacheMock.Received(1).GetBy(cacheKeyComponents.ClientId + "-" + cacheKeyComponents.AccountId);
        }

        [Test]
        public void Get_An_Auth_Token_In_Case_Of_A_Cache_Miss()
        {
            IAuthService authServiceMock = Substitute.For<IAuthService>();
            (string ClientId, string AccountId) cacheKeyComponents = (ClientId: CLIENT_ID, AccountId: ACCOUNT_ID);
            ICache cacheStub = Substitute.For<ICache>();
            cacheStub.GetBy(cacheKeyComponents.ClientId + "-" + cacheKeyComponents.AccountId).Returns(((string RestInstanceUrl, string AccessToken, int ExpiresIn)?)null);
            var sut = new CachingAuthService(authServiceMock, cacheStub, cacheKeyComponents);

            sut.GetToken();

            authServiceMock.Received(1).GetToken();
        }

        [Test]
        public void Store_The_Token_Retrieved_From_The_Token_Api_In_The_Cache()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            authServiceStub.GetToken().Returns<(string, string, int)>((REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN));
            ICache cacheMock = Substitute.For<ICache>();
            (string ClientId, string AccountId) cacheKeyComponents = (ClientId: CLIENT_ID, AccountId: ACCOUNT_ID);
            var sut = new CachingAuthService(authServiceStub, cacheMock, cacheKeyComponents);

            var token = sut.GetToken();

            cacheMock.Received(1).Add(Arg.Is(cacheKeyComponents.ClientId + "-" + cacheKeyComponents.AccountId), Arg.Is(token));
        }

        [Test]
        public void Return_A_Cached_Token_If_It_Exists()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            ICache cacheStub = Substitute.For<ICache>();
            (string ClientId, string AccountId) cacheKeyComponents = (ClientId: CLIENT_ID, AccountId: ACCOUNT_ID);
            cacheStub.GetBy(cacheKeyComponents.ClientId + "-" + cacheKeyComponents.AccountId).Returns<(string, string, int)?>((REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN));
            var sut = new CachingAuthService(authServiceStub, cacheStub, cacheKeyComponents);

            var token = sut.GetToken();

            Assert.AreEqual(REST_INSTANCE_URL, token.RestInstanceUrl);
            Assert.AreEqual(ACCESS_TOKEN, token.AccessToken);
            Assert.AreEqual(EXPIRES_IN, token.ExpiresIn);
        }
    }
}
using NUnit.Framework;
using Salesforce.MarketingCloud.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    class CacheShould
    {
        private const string KEY = "abc-def";
        private string ACCESS_TOKEN = "token";
        private string REST_INSTANCE_URL = "https://rest.salesforce.com";

        [Test]
        public void Return_Null_For_A_Key_That_Doesnt_Exist()
        {
            var sut = new Cache();
            var actualValue = sut.Get(KEY);
            Assert.IsNull(actualValue);
        }

        [Test]
        public void Returns_A_Cached_Value()
        {
            var sut = new Cache();
            sut.Add(KEY, (REST_INSTANCE_URL, ACCESS_TOKEN));
            var actualValue = sut.Get(KEY);

            Assert.IsTrue(actualValue.HasValue);
            Assert.AreEqual(REST_INSTANCE_URL, actualValue.Value.RestInstanceUrl);
            Assert.AreEqual(ACCESS_TOKEN, actualValue.Value.AccessToken);
        }

        // TODO - negative tests for CachingAuthService
    }
}

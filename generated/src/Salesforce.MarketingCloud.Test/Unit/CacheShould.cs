using NSubstitute;
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
        private int EXPIRES_IN = 1000;

        [SetUp]
        public void Setup()
        {
            Cache cache = new Cache(new DefaultDateTimeProvider());
            cache.Delete(KEY);
        }

        [Test]
        public void Return_Null_For_A_Key_That_Doesnt_Exist()
        {
            IDateTimeProvider dateTimeProviderStub = Substitute.For<IDateTimeProvider>();
            var sut = new Cache(dateTimeProviderStub);
            var actualValue = sut.Get(KEY);
            Assert.IsNull(actualValue);
        }

        [Test]
        public void Returns_A_Cached_Value()
        {
            IDateTimeProvider dateTimeProviderStub = Substitute.For<IDateTimeProvider>();
            var sut = new Cache(dateTimeProviderStub);
            sut.Add(KEY, (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN));
            var actualValue = sut.Get(KEY);

            Assert.IsTrue(actualValue.HasValue);
            Assert.AreEqual(REST_INSTANCE_URL, actualValue.Value.RestInstanceUrl);
            Assert.AreEqual(ACCESS_TOKEN, actualValue.Value.AccessToken);
        }

        [Test]
        public void Invalidate_Cached_Value_After_Expiration()
        {
            SettableDateTimeProvider dateTimeProviderStub = new SettableDateTimeProvider();
            var sut = new Cache(dateTimeProviderStub);

            sut.Add(KEY, (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN));

            dateTimeProviderStub.Now = DateTime.Now.AddSeconds(EXPIRES_IN + 1);

            var cachedValue = sut.Get(KEY);

            Assert.IsNull(cachedValue);
        }

        [Test]
        public void Delete_A_Cached_Value()
        {
            SettableDateTimeProvider dateTimeProviderStub = new SettableDateTimeProvider();
            var sut = new Cache(dateTimeProviderStub);

            sut.Add(KEY, (REST_INSTANCE_URL, ACCESS_TOKEN, EXPIRES_IN));

            sut.Delete(KEY);

            var cachedValue = sut.Get(KEY);

            Assert.IsNull(cachedValue);
        }
    }

    class SettableDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get; set; }
    }
}

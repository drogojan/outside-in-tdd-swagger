using NUnit.Framework;
using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Test.Unit
{
    [TestFixture]
    public class CacheShould
    {
        [Test]
        public void Return_Null_For_A_Key_That_Doesnt_Exist()
        {
            var sut = new Cache();
            var entry = sut.GetBy("key");
            Assert.Null(entry);
        }
    }
}
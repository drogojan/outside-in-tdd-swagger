using System;

namespace Salesforce.MarketingCloud.Authentication
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DefaultDateTimeProvider()
        {
        }

        public DateTime Now => DateTime.Now;
    }
}
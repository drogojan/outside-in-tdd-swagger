using System;

namespace Salesforce.MarketingCloud.Authentication
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
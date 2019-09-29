using System;

namespace Salesforce.MarketingCloud.Authentication
{
    public interface ICache
    {
        (string RestInstanceUrl, string AccessToken, int ExpiresIn)? GetBy(string cacheKey);
        void Add(string cacheKey, (string RestInstanceUrl, string AccessToken, int ExpiresIn) tokenTuple);
    }
}
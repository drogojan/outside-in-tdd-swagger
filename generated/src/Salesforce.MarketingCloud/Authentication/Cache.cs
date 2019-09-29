using System;
using System.Collections.Concurrent;

namespace Salesforce.MarketingCloud.Authentication
{
    public class Cache : ICache
    {
        private static ConcurrentDictionary<string, ((string RestInstanceUrl, string AccessToken, int ExpiresIn) token,
            DateTime expiresTime)> cache;

        static Cache()
        {
            cache = new ConcurrentDictionary<string, ((string RestInstanceUrl, string AccessToken, int ExpiresIn) token, DateTime expiresTime)>();
        }

        public (string RestInstanceUrl, string AccessToken, int ExpiresIn)? GetBy(string cacheKey)
        {
            ((string RestInstanceUrl, string AccessToken, int ExpiresIn) token, DateTime expiresTime) token;
            if (cache.TryGetValue(cacheKey, out token))
            {

            }
            return null;
        }

        public void Add(string cacheKey, (string RestInstanceUrl, string AccessToken, int ExpiresIn) tokenTuple)
        {
            throw new System.NotImplementedException();
        }
    }
}
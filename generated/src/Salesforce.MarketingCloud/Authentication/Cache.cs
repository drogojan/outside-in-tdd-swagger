using System;
using System.Collections.Concurrent;

namespace Salesforce.MarketingCloud.Authentication
{
    public class Cache : ICache
    {
        private static ConcurrentDictionary<string, (string RestInstanceUrl, string AccessToken, int ExpiresIn, DateTime ExpireDate)> cache;
        private readonly IDateTimeProvider dateTimeProvider;

        static Cache()
        {
            cache = new ConcurrentDictionary<string, (string RestInstanceUrl, string AccessToken, int ExpiresIn, DateTime ExpireDate)>();
        }

        public Cache(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Add(string key, (string RestInstanceUrl, string AccessToken, int ExpiresIn) token)
        {
            var cachedToken = (token.RestInstanceUrl, token.AccessToken, token.ExpiresIn, this.dateTimeProvider.Now.AddSeconds(token.ExpiresIn));
            cache.AddOrUpdate(key, cachedToken, (cachedKey, cachedValue) => { return cachedToken; });
        }

        public (string RestInstanceUrl, string AccessToken, int ExpiresIn)? Get(string key)
        {
            if(!cache.ContainsKey(key))
            {
                return ((string RestInstanceUrl, string AccessToken, int ExpiresIn)?)null;
            }
            if(this.dateTimeProvider.Now > cache[key].ExpireDate)
            {
                return ((string RestInstanceUrl, string AccessToken, int ExpiresIn)?)null;
            }
            return (cache[key].RestInstanceUrl, cache[key].AccessToken, cache[key].ExpiresIn);
        }

        public void Delete(string key)
        {
            cache.TryRemove(key, out _);
        }
    }
}
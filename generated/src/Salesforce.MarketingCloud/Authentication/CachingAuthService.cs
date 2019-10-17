using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Authentication
{
    public class CachingAuthService : IAuthService
    {
        private readonly IAuthService authService;
        private readonly ICache cache;
        private readonly (string ClienId, string AccountId) tuple;

        public CachingAuthService(IAuthService authService, ICache cache, (string ClienId, string AccountId) tuple)
        {
            this.authService = authService;
            this.cache = cache;
            this.tuple = tuple;
        }

        // TODO - method injection for cache key?

        public (string RestInstanceUrl, string AccessToken, int ExpiresIn) GetToken()
        {
            var cachedValue = cache.Get(tuple.ClienId + "-" + tuple.AccountId);

            if (!cachedValue.HasValue)
            {
                var token = this.authService.GetToken();
                this.cache.Add(tuple.ClienId + "-" + tuple.AccountId, token);
                return (token.RestInstanceUrl, token.AccessToken, token.ExpiresIn);
            }

            return cachedValue.Value;
        }
    }
}
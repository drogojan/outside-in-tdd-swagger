namespace Salesforce.MarketingCloud.Authentication
{
    public class CachingAuthService : IAuthService
    {
        private readonly IAuthService authService;
        private readonly ICache cache;
        private readonly (string ClientId, string AccountId) cacheKeyComponents;

        public CachingAuthService(IAuthService authService, ICache cache,
            (string ClientId, string AccountId) cacheKeyComponents)
        {
            this.authService = authService;
            this.cache = cache;
            this.cacheKeyComponents = cacheKeyComponents;
        }

        public (string RestInstanceUrl, string AccessToken, int ExpiresIn) GetToken()
        {
            var cacheKey = cacheKeyComponents.ClientId + "-" + cacheKeyComponents.AccountId;
            (string RestInstanceUrl, string AccessToken, int ExpiresIn)? cachedValue = cache.GetBy(cacheKey);

            if (!cachedValue.HasValue)
            {
                var token = authService.GetToken();
                this.cache.Add(cacheKey, token);
                return token;
            }

            return cachedValue.Value;
        }
    }
}
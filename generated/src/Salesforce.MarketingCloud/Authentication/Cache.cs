namespace Salesforce.MarketingCloud.Authentication
{
    public class Cache : ICache
    {
        public Cache()
        {
        }

        public void Add(string key, (string RestInstanceUrl, string AccessToken) token)
        {
            throw new System.NotImplementedException();
        }

        public (string RestInstanceUrl, string AccessToken)? Get(string key)
        {
            return null;
        }
    }
}
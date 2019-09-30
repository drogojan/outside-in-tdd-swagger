namespace Salesforce.MarketingCloud.Authentication
{
    public interface ICache
    {
        (string RestInstanceUrl, string AccessToken)? Get(string key);
        void Add(string key, (string RestInstanceUrl, string AccessToken) token);
    }
}
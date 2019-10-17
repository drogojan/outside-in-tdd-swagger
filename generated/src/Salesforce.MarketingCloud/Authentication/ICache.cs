namespace Salesforce.MarketingCloud.Authentication
{
    public interface ICache
    {
        (string RestInstanceUrl, string AccessToken, int ExpiresIn)? Get(string key);
        void Add(string key, (string RestInstanceUrl, string AccessToken, int ExpiresIn) token);
        void Delete(string key);
    }
}
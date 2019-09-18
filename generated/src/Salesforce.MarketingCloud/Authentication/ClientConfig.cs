namespace Salesforce.MarketingCloud.Authentication
{
    public class ClientConfig
    {
        public ClientConfig(string authUrl, string clientId, string clientSecret, string accountId)
        {
            AuthUrl = authUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccountId = accountId;
        }

        public string AuthUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccountId { get; set; }
    }
}
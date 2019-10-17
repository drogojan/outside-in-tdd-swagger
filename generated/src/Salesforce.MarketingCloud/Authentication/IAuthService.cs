namespace Salesforce.MarketingCloud.Authentication
{
    public interface IAuthService
    {
        (string RestInstanceUrl, string AccessToken, int ExpiresIn) GetToken();
    }
}
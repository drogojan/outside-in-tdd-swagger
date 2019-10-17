using System;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using Salesforce.MarketingCloud.Api;
using Salesforce.MarketingCloud.Authentication;
using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Test.Acceptance
{
    [TestFixture]
    public class ApiAccessorShould : AcceptanceTest
    {
        [Test]
        public void Authenticate_The_Request()
        {
            var restClient = new RestClient();
            var clientConfig = new ClientConfig(AuthorizationBaseUrl, ClientId, ClientSecret, AccountId);
            
            var authService = new AuthService(restClient, clientConfig);
            var dateTimeProvider = new DefaultDateTimeProvider();
            var cache = new Cache(dateTimeProvider);
            (string ClientId, string AccountId) tuple = (clientConfig.ClientId, clientConfig.AccountId);
            var cachingAuthService = new CachingAuthService(authService, cache, tuple);
            var serverToServerOAuth2Authenticator = new ServerToServerOAuth2Authenticator(cachingAuthService);

            CampaignApi campaignApi = new CampaignApi(serverToServerOAuth2Authenticator);
            var campaigns = campaignApi.GetAllCampaigns();

            Assert.NotNull(campaigns);
        }
    }
}
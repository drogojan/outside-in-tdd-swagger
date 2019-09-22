using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IRestClient restClient;
        private readonly ClientConfig clientConfig;

        public AuthService(IRestClient restClient, ClientConfig clientConfig)
        {
            this.restClient = restClient;
            this.clientConfig = clientConfig;
        }

        public (string RestInstanceUrl, string AccessToken) GetToken()
        {
            this.restClient.BaseUrl = new Uri(clientConfig.AuthUrl);
            RestRequest tokenRequest = new RestRequest(
                new Uri("v2/token", UriKind.Relative),
                Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            var postBody = GetPostBody();
            tokenRequest.AddJsonBody(postBody);

//            var (accessToken, restInstanceUrl) = 
//                this.restClient.Execute<(string access_token, string rest_instance_url)>(tokenRequest).Data;


            var result = this.restClient.Execute(tokenRequest).Content;

            dynamic jsonResponse = JsonConvert.DeserializeObject(result);

            return (jsonResponse.rest_instance_url, jsonResponse.access_token);
        }

        private JsonObject GetPostBody()
        {
            JsonObject postBody = new JsonObject();
            postBody.Add("client_id", clientConfig.ClientId);
            postBody.Add("client_secret", clientConfig.ClientSecret);
            postBody.Add("account_id", clientConfig.AccountId);
            postBody.Add("grant_type", "client_credentials");
            return postBody;
        }
    }
}
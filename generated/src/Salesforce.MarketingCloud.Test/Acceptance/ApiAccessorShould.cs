using System;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using Salesforce.MarketingCloud.Api;
using Salesforce.MarketingCloud.Authentication;

namespace Salesforce.MarketingCloud.Test.Acceptance
{
    [TestFixture]
    public class ApiAccessorShould
    {
        [Test]
        public void Authenticate_The_Request()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            IAuthenticator authenticatorSpy = Substitute.For<ServerToServerOAuth2Authenticator>(authServiceStub);
            authenticatorSpy.When(m => m.Authenticate(Arg.Any<IRestClient>(), Arg.Any<IRestRequest>())).CallBase();

            CampaignApi campaignApi = new CampaignApi(authenticatorSpy);
            // TODO - remove the try/catch block when all the pieces are in place
            try
            {
                campaignApi.GetAllCampaigns();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            authenticatorSpy.Received(1).Authenticate(Arg.Any<IRestClient>(),
                Arg.Is<IRestRequest>(
                    request =>
                                request.Parameters.Exists(
                                    parameter =>
                                            parameter.Type == ParameterType.HttpHeader 
                                            && parameter.Name == "Authorization" 
                                            && parameter.Value.ToString().StartsWith("Bearer ") 
                                            && parameter.Value.ToString().Length > 7)));
        }
    }
}
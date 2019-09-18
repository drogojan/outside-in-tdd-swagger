/* 
 * Marketing Cloud REST API
 *
 * Marketing Cloud's REST API is our newest API. It supports multi-channel use cases, is much more lightweight and easy to use than our SOAP API, and is getting more comprehensive with every release.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: mc_sdk@salesforce.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Salesforce.MarketingCloud.Client;
using Salesforce.MarketingCloud.Api;
using Salesforce.MarketingCloud.Model;

namespace Salesforce.MarketingCloud.Test
{
    /// <summary>
    ///  Class for testing TransactionalMessagingApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class TransactionalMessagingApiTests
    {
        private TransactionalMessagingApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new TransactionalMessagingApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of TransactionalMessagingApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' TransactionalMessagingApi
            //Assert.IsInstanceOfType(typeof(TransactionalMessagingApi), instance, "instance is a TransactionalMessagingApi");
        }

        
        /// <summary>
        /// Test CreateEmailDefinition
        /// </summary>
        [Test]
        public void CreateEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateEmailDefinitionRequest body = null;
            //var response = instance.CreateEmailDefinition(body);
            //Assert.IsInstanceOf<CreateEmailDefinitionRequest> (response, "response is CreateEmailDefinitionRequest");
        }
        
        /// <summary>
        /// Test CreateSmsDefinition
        /// </summary>
        [Test]
        public void CreateSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateSmsDefinitionRequest body = null;
            //var response = instance.CreateSmsDefinition(body);
            //Assert.IsInstanceOf<CreateSmsDefinitionRequest> (response, "response is CreateSmsDefinitionRequest");
        }
        
        /// <summary>
        /// Test DeleteEmailDefinition
        /// </summary>
        [Test]
        public void DeleteEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.DeleteEmailDefinition(definitionKey);
            //Assert.IsInstanceOf<DeleteSendDefinitionResponse> (response, "response is DeleteSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test DeleteQueuedMessagesForEmailDefinition
        /// </summary>
        [Test]
        public void DeleteQueuedMessagesForEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.DeleteQueuedMessagesForEmailDefinition(definitionKey);
            //Assert.IsInstanceOf<DeleteQueuedMessagesForSendDefinitionResponse> (response, "response is DeleteQueuedMessagesForSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test DeleteQueuedMessagesForSmsDefinition
        /// </summary>
        [Test]
        public void DeleteQueuedMessagesForSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.DeleteQueuedMessagesForSmsDefinition(definitionKey);
            //Assert.IsInstanceOf<DeleteQueuedMessagesForSendDefinitionResponse> (response, "response is DeleteQueuedMessagesForSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test DeleteSmsDefinition
        /// </summary>
        [Test]
        public void DeleteSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.DeleteSmsDefinition(definitionKey);
            //Assert.IsInstanceOf<DeleteSendDefinitionResponse> (response, "response is DeleteSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test GetEmailDefinition
        /// </summary>
        [Test]
        public void GetEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.GetEmailDefinition(definitionKey);
            //Assert.IsInstanceOf<CreateEmailDefinitionRequest> (response, "response is CreateEmailDefinitionRequest");
        }
        
        /// <summary>
        /// Test GetEmailDefinitions
        /// </summary>
        [Test]
        public void GetEmailDefinitionsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string status = null;
            //decimal? pageSize = null;
            //decimal? page = null;
            //string orderBy = null;
            //var response = instance.GetEmailDefinitions(status, pageSize, page, orderBy);
            //Assert.IsInstanceOf<GetEmailDefinitionsResponse> (response, "response is GetEmailDefinitionsResponse");
        }
        
        /// <summary>
        /// Test GetEmailSendStatusForRecipient
        /// </summary>
        [Test]
        public void GetEmailSendStatusForRecipientTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string messageKey = null;
            //var response = instance.GetEmailSendStatusForRecipient(messageKey);
            //Assert.IsInstanceOf<GetDefinitionSendStatusForRecipientResponse> (response, "response is GetDefinitionSendStatusForRecipientResponse");
        }
        
        /// <summary>
        /// Test GetEmailsNotSentToRecipients
        /// </summary>
        [Test]
        public void GetEmailsNotSentToRecipientsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string type = null;
            //int? pageSize = null;
            //int? lastEventId = null;
            //var response = instance.GetEmailsNotSentToRecipients(type, pageSize, lastEventId);
            //Assert.IsInstanceOf<GetDefinitionsNotSentToRecipientsResponse> (response, "response is GetDefinitionsNotSentToRecipientsResponse");
        }
        
        /// <summary>
        /// Test GetQueueMetricsForEmailDefinition
        /// </summary>
        [Test]
        public void GetQueueMetricsForEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.GetQueueMetricsForEmailDefinition(definitionKey);
            //Assert.IsInstanceOf<GetQueueMetricsForSendDefinitionResponse> (response, "response is GetQueueMetricsForSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test GetQueueMetricsForSmsDefinition
        /// </summary>
        [Test]
        public void GetQueueMetricsForSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.GetQueueMetricsForSmsDefinition(definitionKey);
            //Assert.IsInstanceOf<GetQueueMetricsForSendDefinitionResponse> (response, "response is GetQueueMetricsForSendDefinitionResponse");
        }
        
        /// <summary>
        /// Test GetSMSsNotSentToRecipients
        /// </summary>
        [Test]
        public void GetSMSsNotSentToRecipientsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string type = null;
            //int? pageSize = null;
            //int? lastEventId = null;
            //var response = instance.GetSMSsNotSentToRecipients(type, pageSize, lastEventId);
            //Assert.IsInstanceOf<GetDefinitionsNotSentToRecipientsResponse> (response, "response is GetDefinitionsNotSentToRecipientsResponse");
        }
        
        /// <summary>
        /// Test GetSmsDefinition
        /// </summary>
        [Test]
        public void GetSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //var response = instance.GetSmsDefinition(definitionKey);
            //Assert.IsInstanceOf<CreateSmsDefinitionRequest> (response, "response is CreateSmsDefinitionRequest");
        }
        
        /// <summary>
        /// Test GetSmsDefinitions
        /// </summary>
        [Test]
        public void GetSmsDefinitionsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string status = null;
            //decimal? pageSize = null;
            //decimal? page = null;
            //string orderBy = null;
            //var response = instance.GetSmsDefinitions(status, pageSize, page, orderBy);
            //Assert.IsInstanceOf<GetSmsDefinitionsResponse> (response, "response is GetSmsDefinitionsResponse");
        }
        
        /// <summary>
        /// Test GetSmsSendStatusForRecipient
        /// </summary>
        [Test]
        public void GetSmsSendStatusForRecipientTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string messageKey = null;
            //var response = instance.GetSmsSendStatusForRecipient(messageKey);
            //Assert.IsInstanceOf<GetDefinitionSendStatusForRecipientResponse> (response, "response is GetDefinitionSendStatusForRecipientResponse");
        }
        
        /// <summary>
        /// Test PartiallyUpdateEmailDefinition
        /// </summary>
        [Test]
        public void PartiallyUpdateEmailDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //UpdateEmailDefinitionRequest body = null;
            //var response = instance.PartiallyUpdateEmailDefinition(definitionKey, body);
            //Assert.IsInstanceOf<CreateEmailDefinitionRequest> (response, "response is CreateEmailDefinitionRequest");
        }
        
        /// <summary>
        /// Test PartiallyUpdateSmsDefinition
        /// </summary>
        [Test]
        public void PartiallyUpdateSmsDefinitionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string definitionKey = null;
            //UpdateSmsDefinitionRequest body = null;
            //var response = instance.PartiallyUpdateSmsDefinition(definitionKey, body);
            //Assert.IsInstanceOf<CreateSmsDefinitionRequest> (response, "response is CreateSmsDefinitionRequest");
        }
        
        /// <summary>
        /// Test SendEmailToMultipleRecipients
        /// </summary>
        [Test]
        public void SendEmailToMultipleRecipientsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SendEmailToMultipleRecipientsRequest body = null;
            //var response = instance.SendEmailToMultipleRecipients(body);
            //Assert.IsInstanceOf<SendDefinitionToMultipleRecipientsResponse> (response, "response is SendDefinitionToMultipleRecipientsResponse");
        }
        
        /// <summary>
        /// Test SendEmailToSingleRecipient
        /// </summary>
        [Test]
        public void SendEmailToSingleRecipientTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string messageKey = null;
            //SendEmailToSingleRecipientRequest body = null;
            //var response = instance.SendEmailToSingleRecipient(messageKey, body);
            //Assert.IsInstanceOf<SendDefinitionToSingleRecipientResponse> (response, "response is SendDefinitionToSingleRecipientResponse");
        }
        
        /// <summary>
        /// Test SendSmsToMultipleRecipients
        /// </summary>
        [Test]
        public void SendSmsToMultipleRecipientsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SendSmsToMultipleRecipientsRequest body = null;
            //var response = instance.SendSmsToMultipleRecipients(body);
            //Assert.IsInstanceOf<SendDefinitionToMultipleRecipientsResponse> (response, "response is SendDefinitionToMultipleRecipientsResponse");
        }
        
        /// <summary>
        /// Test SendSmsToSingleRecipient
        /// </summary>
        [Test]
        public void SendSmsToSingleRecipientTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string messageKey = null;
            //SendSmsToSingleRecipientRequest body = null;
            //var response = instance.SendSmsToSingleRecipient(messageKey, body);
            //Assert.IsInstanceOf<SendDefinitionToSingleRecipientResponse> (response, "response is SendDefinitionToSingleRecipientResponse");
        }
        
    }

}
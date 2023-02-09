using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit_GitHub_API_Tests.DataModels;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp_API_Tests;
using System;
using System.Net;

namespace NUnit_GitHub_API_Tests
{
    public class NUnit_GitHub_API_Tests
    {
        private const string userName = "desiRadkova";
        private const string userPassword = "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";

        [SetUp]
        public void Setup()
        {
            //var client = new RestClient("https://api.github.com");
           // var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues/4", Method.Get);
            //var requestRepoes = new RestRequest("users/{user}/repos", Method.Get);
            //var requestLabels = new RestRequest("/repos/{user}/{repoName}/issues/{issueNumber}/labels", Method.Get);

            //requestIssues.AddUrlSegment("user", "desiRadkova");
            //requestIssues.AddUrlSegment("repoName", "QA_Automation");

        }

        [Test]
        public void TestGetStatusCode()
        {
            var client = new RestClient("https://api.github.com");
            var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues/4", Method.Get);
            var responseIssues = client.Execute(requestIssues);

            Assert.That(responseIssues.StatusCode, Is.EqualTo(HttpStatusCode.OK),"Http Status Code Properly");

            var issue = JsonConvert.DeserializeObject<DataModels.Issue>(responseIssues.Content);

            Assert.That(issue.title,Is.EqualTo("First Issue"));
            Assert.That(issue.number, Is.EqualTo(4));
        }
        [Test]
        public void TestGetAllIssues()
        {
            var client = new RestClient("https://api.github.com");
            var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues", Method.Get);
            var responseIssues = client.Execute(requestIssues);

            Assert.That(responseIssues.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Http Status Code Properly");

            var issues = JsonConvert.DeserializeObject<List<DataModels.Issue>>(responseIssues.Content);

            foreach(var issue in issues)
            {
                Assert.That(issue.title, Is.Not.Empty);
                Assert.That(issue.number, Is.GreaterThan(0));
            }
            
        }
        [Test]
        public void TestGetLabels()
        {
            var client = new RestClient("https://api.github.com");
            var requestLables = new RestRequest("/repos/desiRadkova/QA_Automation/issues/4/labels", Method.Get);
            var responseLabels = client.Execute(requestLables);

            var labels = JsonConvert.DeserializeObject<List<DataModels.Label>>(responseLabels.Content);
            
            foreach(var label in labels)
            {
                Assert.That(label.id, Is.GreaterThan(0));
                Assert.That(label.name, Is.Not.Empty);
                Assert.That(label.url, Is.Not.Empty);
                Assert.That(label.color, Is.Not.Empty);
                Assert.That(label.description, Is.Not.Empty);
            }
        }

        [Test]
        public void TestGetAllPublicRepos()
        {
            var client = new RestClient("https://api.github.com");
            var requestRepos = new RestRequest("/users/desiRadkova/repos", Method.Get);
            var responseRepos= client.Execute(requestRepos);

            var repos = JsonConvert.DeserializeObject<List<Repo>>(responseRepos.Content);

            foreach(var repo in repos)
            {
                Assert.That(repo.id, Is.GreaterThan(0));
                Assert.That(repo.name, Is.Not.Empty);
                Assert.That(repo.full_name, Is.Not.Empty);
            }
        }

        [Test]
        public void TestPostNewIssue()
        {
            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator(userName,userPassword);
            var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues", Method.Post);
            var issueBody = new
            {
                //id = 11,
                title = "New Test Issue Last",
                body = "This issue is new made for tests",
                labels = new string[] {"bug", "documentation", "issue"}
            };
            requestIssues.AddBody(issueBody);
            
            var responseIssues = client.Execute(requestIssues);
            var issue = JsonConvert.DeserializeObject<DataModels.Issue>(responseIssues.Content);
           
            
            Assert.That(responseIssues.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Http Status Code Properly");
           // Assert.That(issue.id, Is.EqualTo(issueBody.id));
            Assert.That(issue.title, Is.EqualTo(issueBody.title));
            Assert.That(issue.body, Is.EqualTo(issueBody.body));

        }
        [Test]
        public void TestPostEditIssue()
        {
            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator(userName, userPassword);
            var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues/8", Method.Patch);
            requestIssues.AddJsonBody(new
            {
                title = "Edit Issue Last",
                body = "This issue has been edited",
            });

            var responseIssues = client.Execute(requestIssues,Method.Patch);
            var issue = JsonConvert.DeserializeObject<DataModels.Issue>(responseIssues.Content);

            Assert.That(issue.title.Contains("Edit Issue"));
            Assert.That(issue.body.Contains("has been edited"));

        }
        [Test]
        public void TestPostDeleteIssue()//Delete Operation does not work
        {
            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator(userName, userPassword);
            var requestIssues = new RestRequest("/repos/desiRadkova/QA_Automation/issues/43",Method.Get);
  
            var responseIssues = client.Execute(requestIssues,Method.Delete);

            Assert.That(responseIssues.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Http Status Code Properly");
        }

        [TestCase("BG","1000","Sofija")]
        [TestCase("BG", "5000","Veliko Turnovo")]
        [TestCase("CA","M5S","Toronto")]
        [TestCase("GB","B1","Birmingham")]
        [TestCase("DE","01067","Dresden")]
        public void TestGetInformationForUS(string Country, string PostCode,string expectedPlace)
        {
            //https://restcountries.com/v2/name/Bulgaria/
            var client = new RestClient("http://api.zippopotam.us");
            var requestZip = new RestRequest("/"+Country+"/"+PostCode+"", Method.Get);
            var responseZip = client.Execute(requestZip);

            //var bg = JsonConvert.DeserializeObject<List<Countries>>(responseForBg.Content);
            var usZip = JsonConvert.DeserializeObject<ZipCodes>(responseZip.Content);

            StringAssert.Contains(expectedPlace, usZip.Places[0].PlaceName);
            
        }

    }
}
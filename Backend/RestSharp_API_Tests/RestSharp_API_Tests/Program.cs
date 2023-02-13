using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text.Json;

namespace RestSharp_API_Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://api.github.com");
            RestRequest request = new RestRequest("/repos/{user}/{repoName}/issues/4", Method.Get);

            request.AddUrlSegment("user", "desiRadkova");
            request.AddUrlSegment("repoName", "QA_Automation");

            var response = client.Execute(request);
            Console.WriteLine("The Status is: " + response.StatusCode);
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);

            //GET the data for one issue
            Console.WriteLine("GET Data for one issue \n===========================================================");
            Console.WriteLine("Issue title: " + issue.title);
            Console.WriteLine("Issue id: " + issue.id);
            Console.WriteLine("Issue number: " + issue.number);
            Console.WriteLine("Issue body: " + issue.body);

            //GET Data for All issues
            request = new RestRequest("/repos/desiRadkova/QA_Automation/issues", Method.Get);
            response = client.Execute(request);
            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            int i = 0;
            Console.WriteLine("\n\nGET Data for All issues \n==========================================================");
            foreach (var issueData in issues)
            {
                var requestLabels = new RestRequest("/repos/desiRadkova/QA_Automation/issues/" + issueData.number + "/labels", Method.Get);

                var responsed = client.Execute(requestLabels);
                var labels = JsonSerializer.Deserialize<List<Label>>(responsed.Content);
                i++;
                Console.WriteLine("\n--------------------------------------------------------");
                Console.WriteLine("Issue title " + i + ": " + issueData.title);
                Console.WriteLine("Issue id " + i + ": " + issueData.id);
                Console.WriteLine("Issue number " + i + ": " + issueData.number);
                Console.WriteLine("Issue body " + i + ": " + issueData.body);
                int j = 0;
                foreach (var issueLabel in labels)
                {
                    j++;
                    Console.WriteLine("\n\nIssue Label " + j + ": \n***********************************");

                    Console.WriteLine("\nIssue Label ID:");
                    Console.WriteLine("- " + issueLabel.id);

                    Console.WriteLine("\nIssue Label Name:");
                    Console.WriteLine("- " + issueLabel.name);

                    Console.WriteLine("\nIssue Label Description:");
                    Console.WriteLine("- " + issueLabel.description);

                    Console.WriteLine("\nIssue Label Color:");
                    Console.WriteLine("- " + issueLabel.color);

                    Console.WriteLine("\nIssue Label URL:");
                    Console.WriteLine("- " + issueLabel.url);

                    Console.WriteLine("***********************************");
                }
            }

            Console.WriteLine("\n\nCreateing new issue:\n-------------------------------");

            request = new RestRequest("/repos/desiRadkova/QA_Automation/issues", Method.Post);
            client.Authenticator = new HttpBasicAuthenticator("desiRadkova", "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");


            var issueBody = new
            {
                title = "Creating issue with RestSharp",
                body = "This is the body",
                labels = new string[] { "bug", "critical" }
            };
            request.AddBody(issueBody);
            response = client.Execute(request);
            issue = JsonSerializer.Deserialize<Issue>(response.Content);

            //GET the data for new issue
            Console.WriteLine("GET Data for new issue \n===========================================================");
            Console.WriteLine("Issue title: " + issue.title);
            Console.WriteLine("Issue id: " + issue.id);
            Console.WriteLine("Issue number: " + issue.number);
            Console.WriteLine("Issue body: " + issue.body);
        }
    }
}
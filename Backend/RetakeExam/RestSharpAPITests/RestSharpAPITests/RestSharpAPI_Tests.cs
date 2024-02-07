using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {
        private RestClient client;
        private const string baseUrl = "https://shorturl.desirad.repl.co/api";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }

        [Test]
        public void GetAllUrls()
        {
            var expected = "nak, seldev, node";
            RestRequest request = new RestRequest("/urls");
            var response = this.client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var contacts = JsonConvert.DeserializeObject<List<URL>>(response.Content);
            Assert.That(contacts[0].shortCode, Is.EqualTo("nak"));
            Assert.That(contacts[1].shortCode, Is.EqualTo("seldev"));
            Assert.That(contacts[2].shortCode, Is.EqualTo("node"));
        }

        [Test]
        public void FindUrl()
        {
            RestRequest request = new RestRequest("/urls/nak");
            var response = this.client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var shortCodeName = JsonConvert.DeserializeObject<URL>(response.Content);

            Assert.That(shortCodeName.shortCode, Is.EqualTo("nak"));
        }

        [Test]
        public void SearchByInvalidCode()
        {
            var expectedMsg = "Short code not found: new";
            RestRequest request = new RestRequest("/urls/new");
            var response = this.client.Execute(request);


            var err = JsonConvert.DeserializeObject<Error>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(err.errMsg, Is.EqualTo(expectedMsg));
        }
        [Test]
        public void CreateNewUrl()
        {
            RestRequest request = new RestRequest("/urls", Method.Post);

            var body = new { url = "https://new2newURL.org",shortCode = "new2new" };
            request.AddBody(body);
            var response = client.Execute(request);

            var createdUrlResponse = JsonConvert.DeserializeObject<URL>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            //Assert.That(createdUrlResponse, Is.Not.Null);
           // Assert.That(createdUrlResponse.url, Is.EqualTo(body.url));
            //Assert.That(createdUrlResponse.shortCode, Is.EqualTo(body.shortCode));
        }
        [Test]
        public void CreateInvaidNewUrl()
        {
            RestRequest request = new RestRequest("/urls", Method.Post);

            var body = new { url = "https://new2newURL.org", shortCode = "new2new" };
            request.AddBody(body);
            var response = client.Execute(request);

            var createdUrlResponse = JsonConvert.DeserializeObject<URL>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
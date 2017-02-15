namespace Sample01.Tests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;

    public class IntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public IntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder()
             .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestHelloWorldMiddlewareWorks()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(responseString.Contains("Hello World!"));
        }

        [Fact]
        public async Task TestPrimeNumberMiddlewareWorksForANonNumber()
        {
            var response = await _client.GetAsync("/primecheck");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(responseString.Contains("is not prime"));
        }
        [Fact]
        public async Task TestPrimeNumberMiddlewareWorksForANonNumberPrime()
        {
            var response = await _client.GetAsync("/primecheck/4");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(responseString.Contains("is not prime"));
        }
        [Fact]
        public async Task TestPrimeNumberMiddlewareWorksForAPrime()
        {
            var response = await _client.GetAsync("/primecheck/2");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(responseString.Contains("is prime"));
        }
    }
}

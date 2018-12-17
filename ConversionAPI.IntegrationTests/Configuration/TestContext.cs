using System.Net.Http;
using Conversion.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace ConversionAPI.IntegrationTests.Configuration
{
    public class TestContext
    {
        public HttpClient Client { get; private set; }

        public TestContext()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
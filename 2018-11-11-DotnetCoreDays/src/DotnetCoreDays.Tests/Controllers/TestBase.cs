using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace DotnetCoreDays.Tests.Controllers
{
    public abstract class TestBase
    {
        protected TestServer Server { get; }

        protected HttpClient Client { get; }

        public IServiceProvider ServiceProvider { get; }

        protected TestBase()
        {
            Server = new TestServer(
                new WebHostBuilder()
                    .UseContentRoot(CalculateContentRootOfWebProject())
                    .UseStartup<Startup>()
            );

            Client = Server.CreateClient();

            ServiceProvider = Server.Host.Services;
        }

        private string CalculateContentRootOfWebProject()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, "../../../../DotnetCoreDays");
        }
    }
}
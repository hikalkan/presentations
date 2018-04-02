using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MultiTenancyDraft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHostInternal(args).Run();
        }

        public static IWebHost BuildWebHostInternal(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

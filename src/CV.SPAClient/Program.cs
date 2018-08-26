using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CV.SPAClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // TODO: Move to config
                .UseUrls("http://localhost:5000", "https://localhost:5001")
                .UseStartup<Startup>();
    }
}

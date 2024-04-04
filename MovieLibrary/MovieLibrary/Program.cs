
namespace MovieLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("launchSettings.json", optional: true, reloadOnChange: true);
                config.AddJsonFile($"launchSettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
               .ConfigureWebHostDefaults(webHost =>
               {
                   webHost.UseStartup<Startup>();
               });
    }
}

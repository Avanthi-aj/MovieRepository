using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace MovieLibrary.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().
                ConfigureWebHostDefaults(builder =>
                {
                     builder.UseStartup<TestStartup>();
                     builder.UseEnvironment("Testing");
                });
        }
    }
}
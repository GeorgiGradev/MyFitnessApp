using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyFitnessApp.Web.Areas.Identity.IdentityHostingStartup))]

namespace MyFitnessApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}

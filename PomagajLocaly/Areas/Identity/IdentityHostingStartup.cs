
using Microsoft.AspNetCore.Hosting;


[assembly: HostingStartup(typeof(PomagajLocaly.Areas.Identity.IdentityHostingStartup))]
namespace PomagajLocaly.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace Testeer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(owin => owin.UseNancy());
        }
    }
}

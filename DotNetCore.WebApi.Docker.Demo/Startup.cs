using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace DotNetCore.WebApi.Docker.Demo
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(owin => owin.UseNancy());
        }
    }
}

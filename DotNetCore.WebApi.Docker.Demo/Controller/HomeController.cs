using Nancy;

namespace DotNetCore.WebApi.Docker.Demo.Controller
{
    public class HomeController : NancyModule
    {
        public HomeController()
        {
            this.RegisterRoutes();
        }

        public object GetTest()
        {
            return Response.AsJson(new { Message = "This is a simple test" });
        }

        private void RegisterRoutes()
        {
            this.Get("test", args => this.GetTest());
        }
    }
}

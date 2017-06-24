using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testeer.Controller
{
    public class HomeController : NancyModule
    {
        public HomeController()
        {
            this.RegisterRoutes();
        }

        public object GetTest()
        {
            return Response.AsJson(new { we = "Hello World" });
        }

        private void RegisterRoutes()
        {
            this.Get("test", args => this.GetTest());
        }
    }
}

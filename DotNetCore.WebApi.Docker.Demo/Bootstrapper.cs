using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using System.Diagnostics;
using DotNetCore.WebApi.Docker.Demo.Serializer;

namespace DotNetCore.WebApi.Docker.Demo
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            this.AddStopwatch(pipelines);
            this.EnableCors(pipelines);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<JsonSerializer, CustomJsonSerializer>();
        }

        private void EnableCors(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToStartOfPipeline((context) =>
            {
                context.Response
                       .WithHeader("Access-Control-Allow-Origin", "*")
                       .WithHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT,DELETE")
                       .WithHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
            });
        }

        private void AddStopwatch(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline((context) =>
            {
                var stopwatch = Stopwatch.StartNew();
                context.Items.Add("Stopwatch", stopwatch);
                return null;
            });

            pipelines.AfterRequest.AddItemToStartOfPipeline((context) =>
            {
                object objStopwatch;
                context.Items.TryGetValue("Stopwatch", out objStopwatch);
                if (objStopwatch != null)
                {
                    Stopwatch stopwatch = (Stopwatch)objStopwatch;
                    stopwatch.Stop();
                    context.Response.Headers.Add("X-Internal-Time", stopwatch.ElapsedMilliseconds.ToString());
                }
            });
        }
    }
}

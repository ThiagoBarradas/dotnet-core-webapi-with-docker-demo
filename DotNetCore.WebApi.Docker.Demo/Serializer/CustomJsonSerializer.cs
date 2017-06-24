using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetCore.WebApi.Docker.Demo.Serializer
{
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.Formatting = Formatting.Indented;
        }
    }
}

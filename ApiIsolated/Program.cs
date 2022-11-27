using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(options =>
                {
                    options.Services.Configure<JsonSerializerOptions>(jsonSerializerOptions =>
                    {
                        jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                        jsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;


                        // override the default value
                        jsonSerializerOptions.PropertyNameCaseInsensitive = false;
                    });
                } )
                .Build();

            host.Run();
        }
    }
}

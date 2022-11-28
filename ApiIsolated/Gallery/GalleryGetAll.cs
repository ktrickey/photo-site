using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ApiIsolated.Gallery
{
    public class HttpTrigger
    {

        private readonly ILogger _logger;

        public HttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
        }

        [Function("getFullGallery")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "gallery")] HttpRequestData req)
        {
            if (!Directory.Exists("home"))
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(GalleryStructure.Structure);
            return response;
        }



    }
}

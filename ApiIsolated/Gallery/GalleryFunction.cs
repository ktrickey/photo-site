using System.IO;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ApiIsolated.Gallery
{
    public class HttpTrigger
    {
        private static readonly Domain.Gallery GalleryStructure;
        static HttpTrigger()
        {
            Directory.CreateDirectory("home");
            GalleryStructure = Domain.Gallery.GetFolderStructure("home");
        }
        private readonly ILogger _logger;

        public HttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
        }

        [Function("gallery")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            if (!Directory.Exists("home"))
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(GalleryStructure);
            return response;
        }


    }
}

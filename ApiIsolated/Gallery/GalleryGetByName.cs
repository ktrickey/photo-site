using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace ApiIsolated.Gallery;

public class GalleryGetByName
{

    [Function("GalleryGetByName")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "gallery/{name}")] HttpRequestData req, string name)
    {
        var found = GalleryStructure.Structure.Find(name).ToString();
        if (!Directory.Exists("home") || !found.Any())
        {
            return req.CreateResponse(HttpStatusCode.NotFound);
        }
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(found);
        return response;
    }
}

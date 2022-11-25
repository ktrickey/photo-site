using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Api.Gallery;

public static class GalleryFunction
{
    [FunctionName("Gallery")]
    public static ActionResult<Domain.Gallery> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {

        Directory.CreateDirectory("home");
        return new OkObjectResult(Domain.Gallery.GetFolderStructure("gallery"));
    }
}

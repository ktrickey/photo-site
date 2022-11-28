using System.IO;

namespace ApiIsolated.Gallery;

public class GalleryStructure
{
    static GalleryStructure()
    {
        Directory.CreateDirectory("home");
        Structure = Domain.Gallery.GetFolderStructure("home");
    }

    public static Domain.Gallery Structure { get; }
}

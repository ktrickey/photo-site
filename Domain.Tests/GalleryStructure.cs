using System.Text.Json;

namespace Domain.Tests;
[UsesVerify]
public class GalleryStructure
{
    private string[] Directories = new[]
    {
        "home",
        @"home\nature",
        @"home\sport",
        @"home\nature\landscape",
        @"home\nature\wildlife",
        @"home\sport\climbing",
        @"home\sport\football"
    };

    private string[] Photos = new[]
    {
        @"home\nature\001.jpg",
        @"home\nature\002.jpg",
        @"home\nature\003.jpg"
    };
    [Fact]
    public Task ShouldGetStructure()
    {


        foreach (var directory in Directories)
        {
            Directory.CreateDirectory(directory);
        }

        foreach (var photo in Photos)
        {
            File.WriteAllText(photo,photo);
        }
        var galleries = Gallery.GetFolderStructure("home");

        return Verify(galleries);
    }
}

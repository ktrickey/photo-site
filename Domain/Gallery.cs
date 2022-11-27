namespace Domain;

public class Gallery
{
    private readonly string _path;

    private Gallery(string path)
    {
        _path = path;
    }

    public string Name => new DirectoryInfo(_path).Name;

    public IEnumerable<Photo> Photos
    {
        get
        {
            return Directory.GetFiles(_path, "*.jpg", SearchOption.TopDirectoryOnly).Select(p => new Photo(p));
        }
    }
    public IEnumerable<Gallery> Galleries
    {
        get
        {
            var subFolder = Directory.GetDirectories(this._path);
            return subFolder.Select(f=> new Gallery(f));

        }
    }


    public static Gallery GetFolderStructure(string baseFolder)
    {
        return new Gallery(baseFolder);
    }

}

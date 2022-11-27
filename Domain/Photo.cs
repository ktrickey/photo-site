namespace Domain;

public class Photo
{
    public Photo(string filename)
    {
        Location = filename;
    }

    public string Location { get; }
}

namespace WebApi.Entities;

public class StorageRoom
{
    public StorageRoom(int id, string location, Dimensions dimensions, IList<Box> boxes)
    {
        Id = id;
        Location = location;
        Dimensions = dimensions;
        Boxes = boxes;
    }

    public int Id { get; set; }
    public string Location { get; set; }
    public Dimensions Dimensions { get; set; }
    public IList<Box> Boxes { get; set; }
}
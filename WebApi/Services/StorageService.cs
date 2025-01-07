using WebApi.Entities;

namespace WebApi.Services;

public class StorageService:IStorageService
{
    private readonly IList<StorageRoom> _storageRooms;

    public StorageService()
    {
        _storageRooms = new List<StorageRoom>();
        // Seed with at least five rooms and some boxes
        SeedStorageRooms();
    }
    public IList<StorageRoom> GetAllStorageRooms()
    {
        return _storageRooms;
    }
    public StorageRoom? GetStorageRoomById(int id)
    {
        return _storageRooms.FirstOrDefault(room => room.Id == id);
    }
    public void AddStorageRoom(StorageRoom room)
    {
        _storageRooms.Add(room);
    }
    public void AddBoxToRoom(int roomId, Box box)
    {
        var storageRoom = GetStorageRoomById(roomId);//Kate: roomId used here
        if (storageRoom == null)
        {
            throw new ArgumentException($"Room with ID {roomId} not found.");
        }
        // KAte: it is according controller taskGenerate a new ID for the box
        int newBoxId = storageRoom.Boxes.Any() ? storageRoom.Boxes.Max(b => b.Id) + 1 : 1;
        box.Id = newBoxId; // Set the generated ID for the incoming box
        
        //it is standart last line
        storageRoom.Boxes.Add(box);
    }
    private void SeedStorageRooms()
    {
        // Create some predefined Dimensions
        var smallDimensions = new Dimensions(2, 2, 2);
        var mediumDimensions = new Dimensions(5, 5, 5);
        var largeDimensions = new Dimensions(10, 10, 10);

        // Create some boxes
        var box1 = new Box(1, "Kitchen Items", smallDimensions);
        var box2 = new Box(2, "Books", mediumDimensions);
        var box3 = new Box(3, "Clothes", largeDimensions);

        // Create and add storage rooms
        _storageRooms.Add(new StorageRoom(1, "Row 1, Aisle 1", largeDimensions, new List<Box> { box1 }));
        _storageRooms.Add(new StorageRoom(2, "Row 2, Aisle 3", mediumDimensions, new List<Box> { box2 }));
        _storageRooms.Add(new StorageRoom(3, "Row 4, Aisle 7", smallDimensions, new List<Box>()));
        _storageRooms.Add(new StorageRoom(4, "Row 5, Aisle 2", largeDimensions, new List<Box>()));
        _storageRooms.Add(new StorageRoom(5, "Row 7, Aisle 5", mediumDimensions, new List<Box> { box3 }));
    }

}
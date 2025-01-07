using WebApi.Entities;

namespace WebApi.Services;

public interface IStorageService
{
    IList<StorageRoom> GetAllStorageRooms();
    StorageRoom? GetStorageRoomById(int id);
    void AddStorageRoom(StorageRoom room);
    void AddBoxToRoom(int roomId, Box box);
}
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StorageRoomController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageRoomController(IStorageService storageService)
    {
        _storageService = storageService; //Injecting the service
    }

    [HttpGet]
    public IActionResult GetAllRooms()
    {
        var rooms = _storageService.GetAllStorageRooms();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = _storageService.GetStorageRoomById(id);
        if (room == null) return NotFound($"Room with ID {id} not found.");
        return Ok(room);
    }

    [HttpPost]
    public IActionResult AddRoom([FromBody] StorageRoom room)
    {
        if (room == null) return BadRequest("Room cannot be null.");
        _storageService.AddStorageRoom(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
    }

    [HttpPut("{roomId}/boxes")]
    public IActionResult AddBoxToRoom(int roomId, [FromBody] Box box)
    {
        if (box == null) return BadRequest("Invalid box data.");

        try
        {
            _storageService.AddBoxToRoom(roomId, box);
            return Ok($"Box with ID {box.Id} added to room with ID {roomId}.");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message); // Handle room not found error
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}"); // Handle unexpected errors
        }
    }

    [HttpGet("{roomId}/boxes")]
    public IActionResult GetBoxes(int roomId)
    {
        var room = _storageService.GetStorageRoomById(roomId);
        if (room == null) return NotFound($"Room with ID {roomId} not found.");
        return Ok(room.Boxes);
    }

    [HttpDelete("{roomId}/boxes/{boxId}")]
    public IActionResult DeleteBox(int roomId, int boxId)
    {
        var room = _storageService.GetStorageRoomById(roomId);
        if (room == null) return NotFound($"Room with ID {roomId} not found.");
        var box = room.Boxes.FirstOrDefault(b => b.Id == boxId);
        if (box == null) return NotFound($"Box with ID {boxId} not found.");
        room.Boxes.Remove(box);
        return Ok($"Box with ID {boxId} removed from room {roomId}.");
    }
    //2.4.5 Query with Filter
    [HttpGet("filter")]
    public IActionResult FilterRooms([FromQuery] double? minVolume, [FromQuery] int? maxBoxes)
    {
        var rooms = _storageService.GetAllStorageRooms();

        if (minVolume.HasValue)
        {
            rooms = rooms.Where(r =>
                r.Dimensions.Length * r.Dimensions.Width * r.Dimensions.Height > minVolume.Value).ToList();
        }

        if (maxBoxes.HasValue)
        {
            rooms = rooms.Where(r => r.Boxes.Count < maxBoxes.Value).ToList();
        }

        return Ok(rooms);
    }
}
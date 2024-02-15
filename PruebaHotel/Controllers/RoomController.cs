using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Application.Dto;
using PruebaHotel.Application.Service;

namespace PruebaHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("/byHotel/{id}")]
        public async Task<IActionResult> getRoomsByHotel(int id)
        {
            var rooms = _roomService.GetAllByHotelAsync(id);
            return Ok(rooms);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> getRoomsbyId(int id) {
            var room = await _roomService.GetByIdAsync(id);
            return Ok(room);
        }
        
        [HttpPost]
        public async Task<IActionResult> createRoom(CreateRoomIDto roomIDto)
        {
            var room = await _roomService.CreateAsync(roomIDto);
            if (room == null) return NotFound();

            return Ok(room);
        }
        
        [HttpPut]
        public async Task<IActionResult> updateRoom(UpdateRoomIDto roomIDto)
        {
            var room = await _roomService.UpdateAsync(roomIDto);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRoom(int id)
        {
            await _roomService.DeleteAsync(id);
            
            return Ok();

        }

    }
}

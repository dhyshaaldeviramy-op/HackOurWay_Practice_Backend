using HotelBooking.DTO;
using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("by-hotel/{hotelId}")]
        public async Task<IActionResult> GetRoomsByHotel(int hotelId)
        {
            var result = await _roomService.GetRoomsByHotelAsync(hotelId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDTO dto)
        {
            var result = await _roomService.AddRoomAsync(dto);
            return Ok(result);
        }
    }
}
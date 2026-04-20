using HotelBooking.Data;
using HotelBooking.DTO;
using HotelBooking.Model;
using HotelBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomDTO>> GetRoomsByHotelAsync(int hotelId)
        {
            return await _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .Select(r => new RoomDTO
                {
                    Id = r.RoomId,
                    HotelId = r.HotelId,
                    Category = r.Category,
                    Price = r.Price,
                    Availability = r.Availability
                })
                .ToListAsync();
        }

        public async Task<string> AddRoomAsync(CreateRoomDTO dto)
        {
            var hotelExists = await _context.Hotels
                .AnyAsync(h => h.hotelId == dto.HotelId);

            if (!hotelExists)
                throw new Exception("Hotel not found");

            var room = new Room
            {
                HotelId = dto.HotelId,
                Category = dto.Category,
                Price = dto.Price,
                Availability = dto.Availability
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return "Room Added Successfully";
        }
    }
}
using HotelBooking.Data;
using HotelBooking.DTO;
using HotelBooking.Model;
using HotelBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelDTO>> GetAllHotelsAsync()
        {
            return await _context.Hotels
                .Select(h => new HotelDTO
                {
                    Id = h.hotelId,
                    Name = h.HotelName,
                    Location = h.Location
                })
                .ToListAsync();
        }

        public async Task<HotelDTO> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.hotelId == id);

            if (hotel == null)
                throw new Exception("Hotel not found");

            return new HotelDTO
            {
                Id = hotel.hotelId,
                Name = hotel.HotelName,
                Location = hotel.Location
            };
        }

        public async Task<string> AddHotelAsync(CreateHotelDTO dto)
        {
            var hotel = new Hotel
            {
                HotelName = dto.Name,
                Location = dto.Location,
                Description = dto.Description
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return "Hotel Added Successfully";
        }
    }
}
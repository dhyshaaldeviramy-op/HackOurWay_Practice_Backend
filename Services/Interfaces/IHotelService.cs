using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> GetAllHotelsAsync();
        Task<HotelDTO> GetHotelByIdAsync(int id);
        Task<string> AddHotelAsync(CreateHotelDTO dto);
    }
}
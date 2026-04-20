using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetRoomsByHotelAsync(int hotelId);
        Task<string> AddRoomAsync(CreateRoomDTO dto);
    }
}
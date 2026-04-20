using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<string> CreateBookingAsync(int userId, CreateBookingDTO dto);
        Task<List<BookingDTO>> GetBookingsByUserAsync(int userId);
        Task<string> CancelBookingAsync(int bookingId);
    }
}
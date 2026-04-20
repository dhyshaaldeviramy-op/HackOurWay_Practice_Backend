using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDTO dto);
        Task<AuthResponseDto> LoginAsync(LoginDTO dto);
    }
}
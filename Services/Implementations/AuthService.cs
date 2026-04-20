
using HotelBooking.Data;
using HotelBooking.DTO;
using HotelBooking.Helper;
using HotelBooking.Model;
using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly JWTHelper _jwt;

        public AuthService(AppDbContext context,
                           IPasswordHasher<User> hasher,
                           JWTHelper jwt)
        {
            _context = context;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDTO dto)
        {
            bool emailExists = await _context.Users
                .AnyAsync(x => x.email.ToLower() == dto.Email.ToLower());

            if (emailExists)
                throw new Exception("An account with this email already exists.");

            var user = new User
            {
                Name = dto.Name,
                email = dto.Email.ToLower(),
                Role = dto.Role ?? "User"
            };

            user.password = _hasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Email = user.email,
                Role = user.Role,
                Token = _jwt.GenerateToken(user)
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.email.ToLower() == dto.Email.ToLower());

            if (user == null)
                throw new Exception("Invalid email or password.");

            var result = _hasher.VerifyHashedPassword(user, user.password, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid email or password.");

            return new AuthResponseDto
            {
                Email = user.email,
                Role = user.Role,
                Token = _jwt.GenerateToken(user)
            };
        }
    }
}
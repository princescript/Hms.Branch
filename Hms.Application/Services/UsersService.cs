using Hms.Application.Dtos.Auth;
using Hms.Application.Interfaces;
using Hms.Domain.Entities;
using Hms.Domain.Interfaces;

namespace Hms.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;
        private readonly IJwtTokenService _token;
        public UsersService(IUsersRepository repository,IJwtTokenService token)
        {
            _repository = repository;
            _token = token;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var exists = await _repository.UserEmailExistsAsync(dto.Email);
            if (exists)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Email already exists."
                };
            }
            var newUser = new Users
            {
                FullName = dto.FullName.Trim(),
                Email = dto.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User",
                CreatedAtUtc = DateTime.UtcNow
            };
            await _repository.AddUserAsync(newUser);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Registered successfully."
            };

        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _repository.GetUserByEmailAsync(dto.Email);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid email or password."
                };
            }
            var isVerified = BCrypt.Net.BCrypt.Verify(dto.Password,user.PasswordHash);

            if (!isVerified)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid email or password."
                };
            }
            var token = _token.CreateToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Login successful.",
                Token = token
            };

        }
    }
  
}

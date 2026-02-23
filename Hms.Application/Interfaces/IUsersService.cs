using Hms.Application.Dtos.Auth;

namespace Hms.Application.Interfaces
{
    public interface IUsersService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}

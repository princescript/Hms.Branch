
namespace Hms.Application.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string? Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        
    }
}

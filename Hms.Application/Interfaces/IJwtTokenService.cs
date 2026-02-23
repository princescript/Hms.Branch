using Hms.Domain.Entities;

namespace Hms.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(Users user);
    }

}

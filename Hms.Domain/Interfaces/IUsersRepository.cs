using Hms.Domain.Entities;

namespace Hms.Domain.Interfaces
{
    public interface IUsersRepository
    {

        Task<bool> UserEmailExistsAsync(string email);
        Task AddUserAsync(Users user);
        Task<Users?> GetUserByEmailAsync(string email);
        
    }
}

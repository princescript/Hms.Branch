using Hms.Domain;
using Hms.Domain.Entities;
using Hms.Domain.Interfaces;
using Hms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hms.Infrastructure.Repositories
{
    public class UsersRepository :IUsersRepository
    {
        private readonly HmsDbContext _context;
        public UsersRepository(HmsDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UserEmailExistsAsync(string email)
        {
            return await _context.DbUsers.AnyAsync(u=>u.Email == email);

        }
        public async Task AddUserAsync(Users user)
        {
            await _context.DbUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _context.DbUsers.FirstOrDefaultAsync(u=>u.Email == email);
        }
       
    }
}

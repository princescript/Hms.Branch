using Hms.Domain.Entities;
using Hms.Domain.Interfaces;
using Hms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Hms.Infrastructure.Repositories
{
    public class BranchRepository :IBranchRepository
    {
        private readonly HmsDbContext _context;
        public BranchRepository(HmsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Branch>> GetAllAsync()
        {
            return await _context.DbBranch.ToListAsync();
        }
        public async Task<Branch?> GetByIdAsync(int id)
        {
            return await _context.DbBranch.FindAsync(id);
        }

        public async Task CreateAsync(Branch branch)
        { 
            await _context.DbBranch.AddAsync(branch);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Branch branch)
        {
            _context.DbBranch.Update(branch);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Branch branch)
        {
            _context.DbBranch.Remove(branch);
            await _context.SaveChangesAsync();
        }
    }
}

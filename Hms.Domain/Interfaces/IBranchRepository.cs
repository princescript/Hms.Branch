using Hms.Domain.Entities;

namespace Hms.Domain.Interfaces
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> GetByIdAsync(int id);
        Task CreateAsync(Branch branch);
        Task UpdateAsync (Branch branch);
        Task DeleteByIdAsync(Branch branch);
    }
}

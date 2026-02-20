using Hms.Application.Dtos;

namespace Hms.Application.Interfaces
{
    public interface IBranchServices
    {
        Task<IEnumerable<BranchDto>> GetAllAsync();
        Task<BranchDto?> GetByIdAsync(int id);
        Task<BranchDto> CreateAsync(BranchDto branchDto);
        Task<BranchDto?> UpdateAsync(BranchDto branchDto);
        Task<BranchDto?> DeleteByIdAsync(int id);
    }
}

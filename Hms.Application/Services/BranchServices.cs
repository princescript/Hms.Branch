using Hms.Application.Dtos;
using Hms.Application.Interfaces;
using Hms.Domain.Entities;
using Hms.Domain.Interfaces;



namespace Hms.Application.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchRepository _repository;
        public BranchServices(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchDto>> GetAllAsync()
        {
            var branches = await _repository.GetAllAsync();
            return branches.Select(x => new BranchDto
            {
                BranchID = x.BranchID,
                BranchName = x.BranchName,
                BranchCity = x.BranchCity,
                BranchAddress = x.BranchAddress,
            }).ToList();
        }
        public async Task<BranchDto?> GetByIdAsync(int id)
        {
            var branch = await _repository.GetByIdAsync(id);
            if (branch == null) return null;
            return new BranchDto
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName,
                BranchCity = branch.BranchCity,
                BranchAddress = branch.BranchAddress
            };
        }
        public async Task<BranchDto> CreateAsync(BranchDto dto)
        {
            var doctor = new Branch
            {
                BranchID = dto.BranchID,
                BranchName = dto.BranchName,
                BranchCity = dto.BranchCity,
                BranchAddress = dto.BranchAddress
            };
            await _repository.CreateAsync(doctor);
            dto.BranchID = doctor.BranchID;
            return dto;

        }

        public async Task<BranchDto?> UpdateAsync(BranchDto dto)
        {
            if (dto.BranchID <= 0) return null;
            var branch = await _repository.GetByIdAsync(dto.BranchID);
            if (branch == null) return null;

            branch.BranchName = dto.BranchName;
            branch.BranchCity = dto.BranchCity;
            branch.BranchAddress = dto.BranchAddress;
            await _repository.UpdateAsync(branch);

            return dto;
        }

        public async Task<BranchDto?> DeleteByIdAsync(int id)
        {
            var branch = await _repository.GetByIdAsync(id);
            if (branch == null) return null;
            await _repository.DeleteByIdAsync(branch);

            return new BranchDto
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName,
                BranchCity = branch.BranchCity,
                BranchAddress = branch.BranchAddress
            };
        }
    }
}

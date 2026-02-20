using Microsoft.EntityFrameworkCore;
using Hms.Domain.Entities;
namespace Hms.Infrastructure.Data
{
    public class HmsDbContext :DbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options): base(options) { }
        public DbSet<Branch> DbBranch { get; set; }

    }
}

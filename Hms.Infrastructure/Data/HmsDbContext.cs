using Microsoft.EntityFrameworkCore;
using Hms.Domain.Entities;

namespace Hms.Infrastructure.Data
{
    public class HmsDbContext : DbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options)
            : base(options) { }

        public DbSet<Branch> DbBranch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.HasKey(e=>e.BranchID);

                entity.Property(e=>e.BranchName)
                .HasMaxLength(100).IsRequired();

                entity.Property(e=>e.BranchCity)
                .HasMaxLength(100).IsRequired();

                entity.Property(e=>e.BranchAddress)
                .HasMaxLength(250).IsRequired();
                
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
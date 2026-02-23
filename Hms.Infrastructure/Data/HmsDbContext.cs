using Microsoft.EntityFrameworkCore;
using Hms.Domain.Entities;

namespace Hms.Infrastructure.Data
{
    public class HmsDbContext : DbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options)
            : base(options) { }

        public DbSet<Branch> DbBranch { get; set; }
        public DbSet<Users> DbUsers { get; set; }
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
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.FullName)
                .HasMaxLength(150).IsRequired();

                entity.Property(e => e.Email)
                .HasMaxLength(150).IsRequired();

                entity.Property(e => e.PasswordHash)
                .HasMaxLength(500).IsRequired();

                entity.Property(e => e.Role).
                HasMaxLength(50).IsRequired().HasDefaultValue("User");

                entity.Property(e=>e.CreatedAtUtc)
                .HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
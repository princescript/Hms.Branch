using Hms.Domain.Interfaces;
using Hms.Infrastructure.Data;
using Hms.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hms.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<HmsDbContext>(items => items.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBranchRepository, BranchRepository>();
            return services;
        }
    }
}

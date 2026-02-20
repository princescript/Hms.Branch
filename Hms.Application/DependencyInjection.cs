using Hms.Application.Interfaces;
using Hms.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hms.Application
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IBranchServices, BranchServices>();
            return services;
        }
    }
}

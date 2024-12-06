using DDD.Applications.Interfaces;
using DDD.Applications.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInApplicationDependency(this IServiceCollection services)
    {
        // Register Repositories and Services
        services.AddScoped<IStudentService, StudentService>();

        // Add AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}

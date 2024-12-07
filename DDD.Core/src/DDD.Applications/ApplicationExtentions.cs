using DDD.Application;
using DDD.Application.Students;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class ApplicationExtentions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register Repositories and Services
        services.AddScoped(typeof(IApplicationService<>), typeof(ApplicationService<>));
        services.AddScoped<IStudentService, StudentService>();

        // Add AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}

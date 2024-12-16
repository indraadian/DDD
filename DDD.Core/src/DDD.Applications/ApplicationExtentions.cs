using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Base;
using DDD.Application.Services;
using DDD.Application.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Application;

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

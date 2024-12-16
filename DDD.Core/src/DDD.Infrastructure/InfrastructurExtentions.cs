using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Base;
using DDD.Infrastructure.DataContext;
using DDD.Infrastructure.Persistence;
using DDD.Infrastructure.Persistence.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class InfrastructurExtentions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Daftarkan DbContext
        services.AddDbContext<SchoolDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                
        // Daftarkan semua repository
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddScoped<IStudentRepository, StudentRepository>();


        return services;
    }
}

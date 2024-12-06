using DDD.Domain.Entities;
using DDD.Domain.Interfaces;
using DDD.Infrastructure.Data;
using DDD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        // Daftarkan DbContext
        services.AddDbContext<SchoolDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        // Daftarkan semua repository
        services.AddScoped(typeof(IRepository<Student>), typeof(StudentRepository));

        return services;
    }
}

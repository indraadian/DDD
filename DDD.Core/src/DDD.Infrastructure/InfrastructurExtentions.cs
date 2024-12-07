using DDD.Domain;
using DDD.Domain.Students;
using DDD.Infrastructure.Data;
using DDD.Infrastructure.Students;
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
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}

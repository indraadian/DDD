using DDD.Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;

namespace DDD.WebApp;

public static class WebAppExtentions
{
    public static IServiceCollection AddWebApp(this IServiceCollection services)
    {

        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            //options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
        })
            .AddEntityFrameworkStores<SchoolDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

        return services;
    }
}

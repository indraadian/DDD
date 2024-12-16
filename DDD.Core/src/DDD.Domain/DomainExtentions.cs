using Microsoft.Extensions.DependencyInjection;

namespace DDD.Domain
{
    public static class DomainExtentions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}

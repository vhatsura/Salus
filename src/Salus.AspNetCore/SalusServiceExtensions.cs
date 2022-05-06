using Microsoft.Extensions.DependencyInjection;

namespace Salus.AspNetCore;

public static class SalusServiceExtensions
{
    public static IServiceCollection AddIdentityServer(this IServiceCollection services)
    {
        return services;
    }
}

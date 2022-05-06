using Microsoft.AspNetCore.Builder;

namespace Salus.AspNetCore;

public static class SalusApplicationBuilderExtensions
{
    public static IApplicationBuilder UseIdentityServer(this IApplicationBuilder builder)
    {
        return builder;
    }
}

using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Salus.AspNetCore;

public interface IEndpointResult
{
    // todo: think about inheritance from IResult or even return IResult directly from handler
    IResult Execute();
}

public interface IAuthorizeEndpointHandler
{
    Task<IResult> Handle(HttpContext context);
}

internal class AuthorizeEndpointHandler : IAuthorizeEndpointHandler
{
    public async Task<IResult> Handle(HttpContext context)
    {
        IReadOnlyDictionary<string, StringValues> values;

        if (HttpMethods.IsGet(context.Request.Method))
        {
            values = context.Request.Query.ToDictionary(x => x.Key, x => x.Value);
        }
        else if (HttpMethods.IsPost(context.Request.Method))
        {
            if (!HasApplicationFormContentType(context.Request))
            {
                return Results.StatusCode((int)HttpStatusCode.UnsupportedMediaType);
            }

            values = context.Request.Form.ToDictionary(x => x.Key, x => x.Value);
        }
        else
        {
            return Results.StatusCode((int)HttpStatusCode.MethodNotAllowed);
        }

        static bool HasApplicationFormContentType(HttpRequest request)
        {
            if (request.ContentType is null) return false;

            if (MediaTypeHeaderValue.TryParse(request.ContentType, out var header))
            {
                // Content-Type: application/x-www-form-urlencoded; charset=utf-8
                return header.MediaType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}

public static class SalusApplicationBuilderExtensions
{
    public static WebApplication UseIdentityServer(this WebApplication builder)
    {
        builder.UseAuthentication();
        RouteHandlerBuilder endpointBuilder = builder.Map("/connect/authorize",
            async (IAuthorizeEndpointHandler handler, HttpContext context) => await handler.Handle(context));
        endpointBuilder.WithMetadata(new HttpMethodMetadata(new[] { HttpMethods.Get, HttpMethods.Post }));

        return builder;
    }
}

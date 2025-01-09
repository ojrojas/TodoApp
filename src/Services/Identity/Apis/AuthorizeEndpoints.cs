
using Microsoft.AspNetCore.Authentication;

namespace TodoApp.Services.Identity.Apis;

public static class AuthorizeEndpoints
{
    public static RouteGroupBuilder AddAuthorizeEndpoints(this IEndpointRouteBuilder routerBuilder)
    {
        var api = routerBuilder.MapGroup(string.Empty);

        api.MapMethods("/connect/authorize", [HttpMethods.Get, HttpMethods.Post], AuthorizeAppication);
        api.MapPost("/connect/token", ConnectToken);
        api.MapMethods("/connect/logout", [HttpMethods.Get, HttpMethods.Post], LogoutApplication);

        return api;
    }

    private static async Task<IResult> LogoutApplication(HttpContext context, IConfiguration configuration)
    {
        Results.SignOut();
        await context.SignOutAsync(IdentityConstants.ApplicationScheme);
        return Results.Redirect($"{configuration["Identity:Url"]}/index");
    }

    private static async Task ConnectToken(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task AuthorizeAppication(HttpContext context)
    {
        throw new NotImplementedException();
    }
}
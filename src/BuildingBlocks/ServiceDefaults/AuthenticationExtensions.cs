namespace TodoApp.BuildingBlocks.ServiceDefaults.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddDefaultAuthentication(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        // {
        //   "Identity": {
        //     "Url": "http://identity",
        //     "Audience": "basket"
        //    }
        // }

        var identitySection = configuration.GetSection("Identity");

        if (!identitySection.Exists())
        {
            // No identity section, so no authentication
            Console.WriteLine("No Identity Section");
            return services;
        }

        // prevent from mapping "sub" claim to nameidentifier.
        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
        Console.WriteLine("Identity section exists");

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme).AddCookie();

        services.AddAuthorization();

        return services;
    }
}

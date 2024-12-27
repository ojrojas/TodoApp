namespace TodoApp.Services.Identity.DI;

internal static class OpenIddictApplication
{
    public static void AddOpenIddictApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenIddict()
       .AddCore(config =>
       {
           config.UseEntityFrameworkCore()
           .UseDbContext<IdentityDbContext>();
           config.UseQuartz();
       })

       .AddServer(config =>
       {
           config.AllowPasswordFlow();
           config.AllowClientCredentialsFlow();
           config.AllowAuthorizationCodeFlow();
           config.AllowImplicitFlow();
           config.AllowRefreshTokenFlow();

           config.RequireProofKeyForCodeExchange();

           config.SetAuthorizationEndpointUris("/connect/authorize");
           config.SetIntrospectionEndpointUris("/connect/introspect");
           config.SetTokenEndpointUris("/connect/token");


           config.AddEncryptionKey(
                   new SymmetricSecurityKey(
                       Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

           config.AddDevelopmentEncryptionCertificate();
           config.AddDevelopmentSigningCertificate();

           config.UseAspNetCore()
             .DisableTransportSecurityRequirement()
             .EnableAuthorizationEndpointPassthrough()
             .EnableTokenEndpointPassthrough();
       })

       .AddValidation(config =>
       {
           config.UseLocalServer();
           config.UseAspNetCore();
       });
    }
}
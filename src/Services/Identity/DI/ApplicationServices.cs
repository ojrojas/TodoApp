
namespace TodoApp.Services.Identity.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;
        builder.AddServicesWritersLogger();

        var connectionString = configuration.GetConnectionString("identitydb")
           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.AddNpgsqlDbContext<IdentityApplicationDbContext>(connectionName: "identitydb", configureDbContextOptions: options =>
        {
            options.UseOpenIddict();
        });

        builder.EnrichNpgsqlDbContext<IdentityApplicationDbContext>();

        builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        // Add the authentication services to DI
        services.AddIdentityCore<ApplicationUser>()
           .AddEntityFrameworkStores<IdentityApplicationDbContext>()
           .AddDefaultTokenProviders();

        // builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //     .AddEntityFrameworkStores<IdentityApplicationDbContext>()
        //     .AddSignInManager()
        //     .AddDefaultTokenProviders();

        // builder.Services.AddAuthentication(options =>
        // {
        //     options.DefaultScheme = IdentityConstants.ApplicationScheme;
        //     options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        // })
        // .AddIdentityCookies();

        builder.AddDefaultAuthentication();

        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        builder.AddOpenIddictApplication();

    }
}
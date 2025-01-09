namespace TodoApp.Services.Identity.Data;

public class IdentityApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}

namespace Pokegraph.Infrastructure.Persistence;

public sealed class PokegraphDbContext : DbContext
{
    public DbSet<Pokemon> Pokemon { get; set; }

    public PokegraphDbContext(DbContextOptions<PokegraphDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokegraphDbContext).Assembly);               
    }
}
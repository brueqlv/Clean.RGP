using System.Reflection;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Clean.RGP.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }
  public DbSet<Person> People => Set<Person>();
  public DbSet<LandProperty> LandProperties => Set<LandProperty>();
  public DbSet<Plot> Plots => Set<Plot>();
  public DbSet<LandType> LandTypes => Set<LandType>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    modelBuilder.ApplyConfiguration(new PersonConfiguration());
    modelBuilder.ApplyConfiguration(new LandPropertyConfiguration());
    modelBuilder.ApplyConfiguration(new PlotConfiguration());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    if (_dispatcher == null) return result;

    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}

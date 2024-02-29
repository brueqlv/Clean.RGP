using System.Reflection;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
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

    modelBuilder.Entity<Person>()
      .HasKey(p => p.PersonId);

    modelBuilder.Entity<Person>()
      .HasMany(p => p.LandProperties)
      .WithOne(lp => lp.Person)
      .HasForeignKey(lp => lp.PersonId)
      .OnDelete(DeleteBehavior.Cascade);


    modelBuilder.Entity<LandProperty>()
      .HasMany(lp => lp.Plots)
      .WithOne(plot => plot.LandProperty)
      .HasForeignKey(plot => plot.LandPropertyId)
      .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Plot>()
      .HasMany(plot => plot.LandTypes)
      .WithOne(landType => landType.Plot)
      .HasForeignKey(landType => landType.PlotId)
      .OnDelete(DeleteBehavior.Cascade);
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

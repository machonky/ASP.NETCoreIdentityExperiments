using IdentityApp.Models;
using IdentityApp.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Ulid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Required to build the Identity tables
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    public DbSet<IdentityApp.Models.Employee> Employee { get; set; } = default!;

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>()
            .HaveMaxLength(26)
            .AreFixedLength<Ulid>();
    }
}

using IdentityApp.Models;
using IdentityApp.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IdentityApp.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Ulid>
{
    public DbSet<Employee> Employee { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Required to build the Identity tables

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        AssignEntitySchema(modelBuilder);
    }

    protected void AssignEntitySchema(ModelBuilder modelBuilder)
    {
        var appEntityContexts = new[]
        {
            CalcEntityContext(x => x.Employee),
        };

        AssignDefaultSchemaImpl(modelBuilder, appEntityContexts);

        // We're going to give the "Identity" tables new names undecorated by "Asp"
        var authEntityContexts = new[]
        {
            CalcEntityContext(x => x.Users),
            CalcEntityContext(x => x.UserClaims),
            CalcEntityContext(x => x.UserLogins),
            CalcEntityContext(x => x.UserTokens),
            CalcEntityContext(x => x.UserRoles),
            CalcEntityContext(x => x.Roles),
            CalcEntityContext(x => x.RoleClaims),
        };

        AssignDefaultSchemaImpl(modelBuilder, authEntityContexts);
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        // Any encounter with a Ulid will be converted
        // to a string with specific characteristics for the DB.
        configurationBuilder.Properties<Ulid>() 
            .HaveConversion<UlidToStringConverter>()
            .HaveMaxLength(26)
            .AreFixedLength<Ulid>();
    }

    protected class EntityContext
    {
        public EntityContext(string tableName, Type entityType)
        {
            TableName = tableName;
            EntityType = entityType;
        }
        public string TableName { get; init; }
        public Type EntityType { get; init; }
    }

    /// <summary>
    /// Extract the tablename and underlying type from a DBSet
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    protected EntityContext CalcEntityContext<TEntity>(Expression<Func<ApplicationDbContext, DbSet<TEntity>>> expression) where TEntity : class
    {
        var tableName = ((MemberExpression)expression.Body).Member.Name;
        var entityType = ((MemberExpression)expression.Body).Type.GetGenericArguments()[0];
        return new EntityContext(tableName, entityType);
    }

    // Take specific control of the casing convention for the specific type of DB.
    protected virtual string CalcProviderObjectName(string objectName) => objectName;

    protected void AssignDefaultSchemaImpl(ModelBuilder modelBuilder, IEnumerable<EntityContext> entityContexts)
    {
        foreach (var cxt in entityContexts)
        {
            modelBuilder.Entity(cxt.EntityType, entity =>
            {
                entity.ToTable(name: CalcProviderObjectName(cxt.TableName));
            });
        }
    }
}

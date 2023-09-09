using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
        new Role
        {
            Name = "Visitor",
            NormalizedName = "VISITOR"
        },
        new Role
        {
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        });
    }
}
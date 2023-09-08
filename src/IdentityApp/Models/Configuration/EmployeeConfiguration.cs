using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee
            {
                Id = Ulid.Parse("01H9T4G7T25PPF0DMY6DMHWCDT"),
                Name = "Ervin K. Cole",
                Age = 26,
                Position = "Software Developer"
            },
            new Employee
            {
                Id = Ulid.Parse("01H9T4GARX3V9F02WSQJKTPP3H"),
                Name = "Sara B. Welker",
                Age = 31,
                Position = "Software Developer"
            }
        );
    }
}

using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Models;

public class Employee
{
    public Ulid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string Position { get; set; }
}

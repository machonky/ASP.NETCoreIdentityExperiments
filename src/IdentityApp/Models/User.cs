using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace IdentityApp.Models;

public class User : IdentityUser<Ulid>
{ 
    public User()
    {
        Id = Ulid.NewUlid();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string? ConcurrencyStamp { get; set; } = Ulid.NewUlid().ToString();
}


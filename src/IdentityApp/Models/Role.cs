using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models;

public class Role : IdentityRole<Ulid>
{ 
    public Role()
    {
        Id = Ulid.NewUlid();
    }

    public override string? ConcurrencyStamp { get; set; } = Ulid.NewUlid().ToString();
}

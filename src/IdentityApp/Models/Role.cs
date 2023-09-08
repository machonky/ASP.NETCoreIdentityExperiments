using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models;

public class Role : IdentityRole<Ulid>
{ 
    public Role()
    {
        Id = Ulid.NewUlid();
    }
}

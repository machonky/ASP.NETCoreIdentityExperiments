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
}

//public class UserClaim : IdentityUserClaim<Ulid>
//{ }

//public class UserRole : IdentityUserRole<Ulid>
//{ }

//public class UserLogin : IdentityUserLogin<Ulid>
//{ }

//public class UserToken : IdentityUserToken<Ulid>
//{ }

//public class RoleClaim : IdentityRoleClaim<Ulid>
//{ }


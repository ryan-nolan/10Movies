using Microsoft.AspNetCore.Identity;

namespace TenMovies.Web.Models.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

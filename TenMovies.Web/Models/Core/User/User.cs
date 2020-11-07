using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TenMovies.Web.Models.Core.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

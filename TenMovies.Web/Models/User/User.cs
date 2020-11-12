using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Models.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

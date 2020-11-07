using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TenMovies.Web.Models.ViewModels
{
    public class UserRegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

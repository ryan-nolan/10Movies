using System.Collections.Generic;
using TenMovies.Web.Models.Entities;

namespace TenMovies.Web.Models.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void AddUser(string username, string password, string firstName, string lastName);
    }
}
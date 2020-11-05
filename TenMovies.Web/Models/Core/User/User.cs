using System.Collections.Generic;

namespace TenMovies.Web.Models.Core.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public IEnumerable<User> GetUsers()
        {
            return new List<User>() { new User { Id = 101, Username = "test", Name = "Test", EmailId = "test@test.com", Password = "pass" } };
        }
    }
}

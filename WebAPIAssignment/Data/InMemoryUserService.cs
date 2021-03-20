using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Data
{
    public class InMemoryUserService : IUserService
    {
        private ICollection<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin",
                    SecurityLevel = 1
                }
            }.ToList();
        }

        public async Task<User> ValidateUser(string UserName, string Password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(UserName) && user.Password.Equals(Password));
            if (first == null)
                throw new Exception("User not found.");
            return first;
        }
    }
}

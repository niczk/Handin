using Handin1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handin1.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

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

        public User ValidateUser(string UserName, string Passord)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(UserName));
            if (first == null)
                throw new Exception("User not found.");
            if (!first.Password.Equals(Passord))
                throw new Exception("Incorect password.");
            return first;
        }
    }
}

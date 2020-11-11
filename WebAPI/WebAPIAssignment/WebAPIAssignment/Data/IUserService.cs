using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string UserName, string Password);
    }
}

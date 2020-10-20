using Handin1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handin1.Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Passord);
    }
}

using Handin1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handin1.Data
{
    public interface IAdultList
    {
        Task<IList<Adult>> GetAdults();
        Task<Adult> GetAdult(int adultId);
        Task AddAdult(Adult adult);
        Task RemoveAdult(int adultId);
        Task UpdateAdult(Adult adult);
    }
}

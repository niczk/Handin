using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public interface IAdultList
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
    }
}

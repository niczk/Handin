using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class AdultList : IAdultList
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultList()
        {
            string content = File.ReadAllText(adultFile);
            adults = JsonSerializer.Deserialize<List<Adult>>(content);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteTodosToFile();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toRemove = adults.First(a => a.Id == adultId);
            adults.Remove(toRemove);
            WriteTodosToFile();
        }

        private void WriteTodosToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(adults);

            File.WriteAllText(adultFile, productsAsJson);
        }
    }
}

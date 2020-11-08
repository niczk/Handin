using Handin1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Handin1.Data
{
    public class AdultList : IAdultList
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultList()
        {
            if(!File.Exists(adultFile))
            {
                Adult[] ads = { };
                adults = ads.ToList();

                string productAsJson = JsonSerializer.Serialize(adults);
                File.WriteAllText(adultFile, productAsJson);
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public async Task AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id); //get last ID
            adult.Id = (++max); //saving last id+1
            adults.Add(adult); //save adult
            SaveToJson();
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults); //copy list (just for sure)
            return tmp;
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(a => a.Id == adultId);
            adults.Remove(toRemove);
            SaveToJson();
        }

        private void SaveToJson()
        {
            string productAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productAsJson);
        }
    }
}

using Handin1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Handin1.Data
{
    public class CloudAdultList : IAdultList
    {
        private string url = "http://dnp.metamate.me";
        private readonly HttpClient client;
        public CloudAdultList()
        {
            client = new HttpClient();
        }
        public async Task AddAdult(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PutAsync(url + "/adults", content);
        }

        public async Task<IList<Adult>> GetAdults()
        {
            Task<string> stringAsync = client.GetStringAsync(url + "/adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task RemoveAdult(int adultId)
        {
            await client.DeleteAsync($"{url}/adults/{adultId}");
        }
    }
}

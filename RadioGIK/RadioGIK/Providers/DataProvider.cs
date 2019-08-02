using Newtonsoft.Json;
using RadioGIK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RadioGIK.Providers
{
    public class DataProvider
    {
        public async Task<SongInfo> GetSongInfoAsync(string path)
        {
            SongInfo songInfo;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);

                var httpResponse = await client.GetAsync(client.BaseAddress);

                httpResponse.EnsureSuccessStatusCode();

                HttpContent content = httpResponse.Content;
                var json = await content.ReadAsStringAsync();
                songInfo = JsonConvert.DeserializeObject<SongInfo>(json);
            }
            return songInfo;
        }

        public async Task<ObservableCollection<Info>> GetInfoAsync(string path)
        {
            ObservableCollection<Info> infos;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);

                var httpResponse = await client.GetAsync(client.BaseAddress);

                httpResponse.EnsureSuccessStatusCode();

                HttpContent content = httpResponse.Content;
                var json = await content.ReadAsStringAsync();
                infos = JsonConvert.DeserializeObject<ObservableCollection<Info>>(json);
            }
            return infos; ;
        }
    }
}

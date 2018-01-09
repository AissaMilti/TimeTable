using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace TimeTable.Services
{
    public class ApiService
    {

        public async Task<RootObject2> GetDepartures(string locationInput)
        {
            using (var locationClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(
                        "https://api.resrobot.se/v2/location.name?key=f4b8b37f-cd78-4399-84b6-00dd5c23fab3&input="
                        + locationInput + "&format=json")
                };

                var response = await locationClient.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<RootObject>(data);

                var station = posts.StopLocation.First();

                var stationId = station.id;

                var req = new HttpRequestMessage
                {
                    RequestUri = new Uri(
                        "https://api.resrobot.se/v2/departureBoard?key=49dfb3aa-5d06-40b0-a370-2fb671ef908f&id="
                        + stationId + "&format=json")
                };

                var res = await locationClient.SendAsync(req);
                var data2 = await res.Content.ReadAsStringAsync();
                var resu = JsonConvert.DeserializeObject<RootObject2>(data2);

                return resu;
            }
        }
    }
}
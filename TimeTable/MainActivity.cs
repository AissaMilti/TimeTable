using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using Android.Provider;
using Newtonsoft.Json;


namespace TimeTable
{
    [Activity(Label = "Tidtabeller i Stockholm", MainLauncher = true)]
    public class MainActivity : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnGetTable = FindViewById<Button>(Resource.Id.btnGetTable);
            

            btnGetTable.Click += BtnGetTableOnClick;

        }

        public async void BtnGetTableOnClick(object sender, EventArgs eventArgs)
        {
            EditText location = FindViewById<EditText>(Resource.Id.inputTable);

            TextView txtStation = FindViewById<TextView>(Resource.Id.txtStation);
            TextView txtDeparture = FindViewById<TextView>(Resource.Id.txtDeparture);
            TextView txtDestination = FindViewById<TextView>(Resource.Id.txtDestination);
            TextView txtStation2 = FindViewById<TextView>(Resource.Id.txtStation2);
            TextView txtDepature2 = FindViewById<TextView>(Resource.Id.txtDeparture2);
            TextView txtDestination2 = FindViewById<TextView>(Resource.Id.txtDestination2);

            using (var locationClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://api.resrobot.se/v2/location.name?key=f4b8b37f-cd78-4399-84b6-00dd5c23fab3&input=" 
                                         + location.Text + "&format=json")      
                };
                
                var response = await locationClient.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<RootObject>(data);

                var station = posts.StopLocation.First();

                var stationId = station.id;

                var req = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://api.resrobot.se/v2/departureBoard?key=49dfb3aa-5d06-40b0-a370-2fb671ef908f&id=" 
                                         + stationId + "&format=json")
                };

                var res = await locationClient.SendAsync(req);
                var data2 = await res.Content.ReadAsStringAsync();
                var resu = JsonConvert.DeserializeObject<RootObject2>(data2);

                var departureTime = resu.Departure[0].Stops.Stop[0].depTime;
                var stationName = resu.Departure[0].Stops.Stop[0].name;
                var destination = resu.Departure[0].direction;

                var departureTime2 = resu.Departure[1].Stops.Stop[0].depTime;
                var stationName2 = resu.Departure[1].Stops.Stop[0].name;
                var destination2 = resu.Departure[1].direction;

               
                txtStation.Text = stationName;
                txtDeparture.Text = departureTime;
                txtDestination.Text = destination;
                txtStation2.Text = stationName2;
                txtDepature2.Text = departureTime2;
                txtDestination2.Text = destination2;




            }

        }
    }
}


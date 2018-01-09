using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using Android.Provider;
using Java.Security;
using Newtonsoft.Json;
using TimeTable.Services;


namespace TimeTable
{

    [Activity(Label = "Tidtabeller i Stockholm", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private readonly ApiService _apiService = new ApiService();

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
            var data = await _apiService.GetDepartures(location.Text);


            TextView txtStation = FindViewById<TextView>(Resource.Id.txtStation);
            TextView txtDeparture = FindViewById<TextView>(Resource.Id.txtDeparture);
            TextView txtDestination = FindViewById<TextView>(Resource.Id.txtDestination);
            TextView txtStation2 = FindViewById<TextView>(Resource.Id.txtStation2);
            TextView txtDepature2 = FindViewById<TextView>(Resource.Id.txtDeparture2);
            TextView txtDestination2 = FindViewById<TextView>(Resource.Id.txtDestination2);
            TextView txtStation3 = FindViewById<TextView>(Resource.Id.txtStation3);
            TextView txtDepature3 = FindViewById<TextView>(Resource.Id.txtDeparture3);
            TextView txtDestination3 = FindViewById<TextView>(Resource.Id.txtDestination3);
            TextView txtStation4 = FindViewById<TextView>(Resource.Id.txtStation4);
            TextView txtDepature4 = FindViewById<TextView>(Resource.Id.txtDeparture4);
            TextView txtDestination4 = FindViewById<TextView>(Resource.Id.txtDestination4);


            var departureTime = data.Departure[0].Stops.Stop[0].depTime;
            var stationName = data.Departure[0].Stops.Stop[0].name;
            var destination = data.Departure[0].direction;

            var departureTime2 = data.Departure[1].Stops.Stop[0].depTime;
            var stationName2 = data.Departure[1].Stops.Stop[0].name;
            var destination2 = data.Departure[1].direction;

            var departureTime3 = data.Departure[2].Stops.Stop[0].depTime;
            var stationName3 = data.Departure[2].Stops.Stop[0].name;
            var destination3 = data.Departure[2].direction;

            var departureTime4 = data.Departure[3].Stops.Stop[0].depTime;
            var stationName4 = data.Departure[3].Stops.Stop[0].name;
            var destination4 = data.Departure[3].direction;


            txtStation.Text = stationName;
            txtDeparture.Text = departureTime;
            txtDestination.Text = destination;
            txtStation2.Text = stationName2;
            txtDepature2.Text = departureTime2;
            txtDestination2.Text = destination2;

            txtStation3.Text = stationName3;
            txtDepature3.Text = departureTime3;
            txtDestination3.Text = destination3;
            txtStation4.Text = stationName4;
            txtDepature4.Text = departureTime4;
            txtDestination4.Text = destination4;


        }
    }
}



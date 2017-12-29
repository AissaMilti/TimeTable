using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TimeTable
{
    public class StopLocation
    {
        public string id { get; set; }
        public string extId { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public int weight { get; set; }
        public int products { get; set; }
    }

    public class RootObject
    {
        public List<StopLocation> StopLocation { get; set; }
    }
}
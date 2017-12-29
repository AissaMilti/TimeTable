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
    public class Product
    {
        public string name { get; set; }
        public string num { get; set; }
        public string catCode { get; set; }
        public string catOutS { get; set; }
        public string catOutL { get; set; }
        public string operatorCode { get; set; }
        public string @operator { get; set; }
        public string operatorUrl { get; set; }
    }

    public class Stop
    {
        public string name { get; set; }
        public string id { get; set; }
        public string extId { get; set; }
        public int routeIdx { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string depTime { get; set; }
        public string depDate { get; set; }
        public string rtDepTime { get; set; }
        public string rtDepDate { get; set; }
        public string rtDepTrack { get; set; }
        public string arrTime { get; set; }
        public string arrDate { get; set; }
    }

    public class Stops
    {
        public List<Stop> Stop { get; set; }
    }

    public class Departure
    {
        public Product Product { get; set; }
        public Stops Stops { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string stop { get; set; }
        public string stopid { get; set; }
        public string stopExtId { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public string rtTime { get; set; }
        public string rtDate { get; set; }
        public string rtTrack { get; set; }
        public string direction { get; set; }
        public string transportNumber { get; set; }
        public string transportCategory { get; set; }
    }

    public class RootObject2
    {
        public List<Departure> Departure { get; set; }
    }
}
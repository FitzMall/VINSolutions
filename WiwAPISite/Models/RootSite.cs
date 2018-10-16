using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WiwAPISite.Models
{
   
    public class RootSite
    {
        public Site[] sites { get; set; }
    }

    public class Site
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public int location_id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string place_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool is_deleted { get; set; }
        public string deleted_at { get; set; }
        public float?[] coordinates { get; set; }
        public int radius { get; set; }
    }

    public class FitzSite
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public int location_id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string place_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool is_deleted { get; set; }
        public string deleted_at { get; set; }
        public int radius { get; set; }

    }

}
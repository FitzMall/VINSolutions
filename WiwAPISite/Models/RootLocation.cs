using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiwAPISite.Models
{

    public class RootLocation
    {
        public Location[] locations { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public int is_default { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
        public int max_hours { get; set; }
        public string address { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int place_id { get; set; }
        public bool place_confirmed { get; set; }
        public string ip_address { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public bool is_deleted { get; set; }
        public string deleted_at { get; set; }
        public float[] coordinates { get; set; }
        public int radius { get; set; }
        public Place place { get; set; }
    }


    public class FitzLocation
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public string is_default { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
     

    }


    public class Place
    {
        public int id { get; set; }
        public string business_name { get; set; }
        public string address { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
        public string locality { get; set; }
        public string sub_locality { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string[] place_type { get; set; }
        public string place_id { get; set; }
        public string updated_at { get; set; }
    }

}

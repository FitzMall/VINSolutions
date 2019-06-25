using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiwAPISite.Models
{
    public class RootShift
    {
        public string start { get; set; }
        public string end { get; set; }
        public Shift[] shifts { get; set; }
        public Shiftchain[] shiftchains { get; set; }
        public User[] users { get; set; }
        public Location[] locations { get; set; }
        public Position[] positions { get; set; }
    }

    public class Shift
    {
        public long id { get; set; }
        public int account_id { get; set; }
        public int user_id { get; set; }
        public int location_id { get; set; }
        public int position_id { get; set; }
        public int site_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public float break_time { get; set; }
        public string color { get; set; }
        public string notes { get; set; }
        public bool alerted { get; set; }
        public object linked_users { get; set; }
        public string shiftchain_key { get; set; }
        public bool published { get; set; }
        public string published_date { get; set; }
        public string notified_at { get; set; }
        public int instances { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int acknowledged { get; set; }
        public string acknowledged_at { get; set; }
        public int creator_id { get; set; }
        public bool is_open { get; set; }
        public bool actionable { get; set; }
        public int block_id { get; set; }
    }

    public class FitzShift
    {
        public long id { get; set; }
        public int account_id { get; set; }
        public int user_id { get; set; }
        public int location_id { get; set; }
        public int position_id { get; set; }
        public int site_id { get; set; }

        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }

        public float break_time { get; set; }

        public string color { get; set; }
        public string notes { get; set; }

        public bool alerted { get; set; }
        //public object linked_users { get; set; }
        //public string shiftchain_key { get; set; }
        public bool published { get; set; }
        public string published_date { get; set; }

        public string notified_at { get; set; }
       // public int instances { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public int acknowledged { get; set; }
        public string acknowledged_at { get; set; }

        public int creator_id { get; set; }
        public bool is_open { get; set; }
        public bool actionable { get; set; }

   

    }
  
    public class Shiftchain
    {
        public string key { get; set; }
        public int account_id { get; set; }
        public int week { get; set; }
        public string until { get; set; }
        public int count { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}

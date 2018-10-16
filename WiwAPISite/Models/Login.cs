using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WiwAPISite.Models
{
    public class Login
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class UserModel
    {
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RecordStatusCode { get; set; }
        public string LastClockInUTCDate { get; set; }
        public string LastClockOutUTCDate { get; set; }
        public string LastMobileLoginDLTDate { get; set; }
        public string LastBrowserLoginDLTDate { get; set; }
        public DateTime? LastUpdatedUTCDate { get; set; }
    }
}
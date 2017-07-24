using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class LeadStatusCustomModel
    {
        public long DealerID { get; set; }
        public long LeadStatusCustomID { get; set; }
        public string LeadStatusName { get; set; }
        public long LeadStatusTypeID { get; set; }
        public string LeadStatusTypeName { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
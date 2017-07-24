using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class LeadSourceModel
    {
        public long DealerID { get; set; }
        public long LeadSourceID { get; set; }
        public long LeadTypeID { get; set; }
        public string LeadSourceName { get; set; }
        public string LeadSourceTypeName { get; set; }
        public string LeadSourceGroupName { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
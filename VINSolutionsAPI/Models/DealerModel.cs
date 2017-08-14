using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class DealerModel
    {
        public long DealerID { get; set; }
        public string DealerName { get; set; }
        public string DealerBrands { get; set; }
        public string DealerAddress { get; set; }
        public string DealerCity { get; set; }
        public string DealerStateProvince { get; set; }
        public string DealerPostalCode { get; set; }
        public string DealerCountry { get; set; }
        public string RecordStatusCode { get; set; }
        public DateTime? LastUpdatedUTCDate { get; set; }

    }
}
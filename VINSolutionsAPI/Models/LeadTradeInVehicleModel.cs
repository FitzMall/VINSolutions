using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class LeadTradeInVehicleModel
    {
        public long DealerID { get; set; }
        public long CustomerID { get; set; }
        public long LeadID { get; set; }
        public long TradeInID { get; set; }
        public string VIN { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public int? Odometer { get; set; }
        public string RecordStatusCode { get; set; }
        public decimal? TradePayoff { get; set; }
        public decimal? TradeACV { get; set; }
        public decimal? TradeAllowance { get; set; }
        public int? AppraisalByUserID { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
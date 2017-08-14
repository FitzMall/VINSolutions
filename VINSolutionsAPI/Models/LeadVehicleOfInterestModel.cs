using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class LeadVehicleOfInterestModel
    {
        public long DealerID { get; set; }
        public long VehicleOfInterestID { get; set; }
        public long LeadID { get; set; }
        public long AutoID { get; set; }
        public string InventoryType { get; set; }
        public string StockNumber { get; set; }
        public string VIN { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public string Odometer { get; set; }
        public decimal? Price { get; set; }
        public bool IsPrimary { get; set; }
        public string RecordStatusCode { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
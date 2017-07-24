using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class InventoryModel
    {
        public long DealerID { get; set; }
        public long VehicleID { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string InventoryType { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Odometer { get; set; }
        public string Price { get; set; }
        public string InternetPrice { get; set; }
        public string ComparePrice { get; set; }
        public string Cost { get; set; }
        public long PhotoCount { get; set; }
        public bool HasVideo { get; set; }
        public bool HasCarfax { get; set; }
        public bool HasComments { get; set; }
        public string VehicleType { get; set; }
        public string RecordStatusCode { get; set; }
        public DateTime InventoryUTCDate { get; set; }
        public string RemovalUTCDate { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }

    }
}
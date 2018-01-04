using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class ServiceVisitModel
    {
        public long DealerID { get; set; }
        public long? CustomerID { get; set; }
        public long RepairOrderID { get; set; }
        public long RepairOrderNumber { get; set; }
        public string VIN { get; set; }
        public string Odometer { get; set; }
        public string ServiceAdvisorUserID { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string PartsTotal { get; set; }
        public string LaborTotal { get; set; }
        public string TotalServiceHours { get; set; }
        public string LaborDescription { get; set; }
        public string LaborLineCount { get; set; }
        public string DealerPaidAmount { get; set; }
        public string CustomerPaidAmount { get; set; }
        public string WarrantyPaidAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public string ROOpenedDate { get; set; }
        public string ROClosedDate { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class UserAccessModel
    {
        public long DealerID { get; set; }
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long InventoryAccessLevelID { get; set; }
        public string InventoryAccessLevelName { get; set; }
        public string CRMAccessLevelID { get; set; }
        public string CRMAccessLevelName { get; set; }
        public bool SalespersonInd { get; set; }
        public bool InternetSalespersonInd { get; set; }
        public bool SalesManagerInd { get; set; }
        public bool BDAgentInd { get; set; }
        public bool CSIAgentInd { get; set; }
        public bool ServiceAgentInd { get; set; }
        public bool FinanceMgrInd { get; set; }
        public string UserGroupName { get; set; }
        public string RecordStatusCode { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
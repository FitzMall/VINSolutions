using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class LeadModel
    {
        public long DealerID { get; set; }
        public long LeadID { get; set; }
        public long CustomerID { get; set; }
        public string SalesRepUserID { get; set; }
        public string LeadSourceID { get; set; }
        public string LeadTypeID { get; set; }
        public string LeadStatusID { get; set; }
        public string LeadStatusCustomID { get; set; }
        public long LeadStatusTypeID { get; set; }
        public bool ADFXML { get; set; }
        public string FirstAttemptedContactUTCDate { get; set; }
        public string LastAttemptedContactUTCDate { get; set; }
        public string LastAttemptedEmailContactUTCDate { get; set; }
        public string LastAttemptedPhoneContactUTCDate { get; set; }
        public string LastCustomerContactUTCDate { get; set; }
        public string LastAttemptedOrActualContactUTCDate { get; set; }
        public string DealerActionableUTCDate { get; set; }
        public bool HasBeenContacted { get; set; }
        public bool HasVehicleOfInterest { get; set; }
        public bool OriginatedAfterHours { get; set; }
        public string AdjustedResponseTimeInMinutes { get; set; }
        public string ActualResponseTimeInMinutes { get; set; }
        public DateTime OriginationUTCDate { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }

    }
}
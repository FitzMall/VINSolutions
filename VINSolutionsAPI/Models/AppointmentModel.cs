using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class AppointmentModel
    {
        public long DealerID { get; set; }
        public long AppointmentID { get; set; }
        public long CustomerID { get; set; }
        public string LeadID { get; set; }
        public string VisitID { get; set; }
        public bool IsShow { get; set; }
        public bool IsNoShow { get; set; }
        public string AppointmentType { get; set; }
        public string AssignedToUserID { get; set; }
        public string AppointmentStartUTCDate { get; set; }
        public string ScheduledUTCDate { get; set; }
        public string ScheduledByUserID { get; set; }
        public string ConfirmedUTCDate { get; set; }
        public string ConfirmedByUserID { get; set; }
        public string RescheduledUTCDate { get; set; }
        public string RescheduledByUserID { get; set; }
        public string CompletedUTCDate { get; set; }
        public string CompletedByUserID { get; set; }
        public string AppointmentStatus { get; set; }
        public string LastUpdatedByUserID { get; set; }
        public string LastUpdatedUTCDate { get; set; }
        public long? LeadSourceID { get; set; }

    }
}
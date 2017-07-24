using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class ShowroomVisitModel
    {
        public long DealerID { get; set; }
        public long VisitID { get; set; }
        public long LeadID { get; set; }
        public string CreatedByUserID { get; set; }
        public string CompletedByUserID { get; set; }
        public string TurnOverManagerUserID { get; set; }
        public string StartUTCDate { get; set; }
        public string EndUTCDate { get; set; }
        public string EndReasonID { get; set; }
        public string EndReasonDescription { get; set; }
        public string ResultID { get; set; }
        public string ResultDescription { get; set; }
        public bool BeBack { get; set; }
        public string LeadMessageType { get; set; }
        public bool ContactedAfterVisit { get; set; }
        public bool WalkAround { get; set; }
        public bool TradeAppraisal { get; set; }
        public bool DemoTestDrive { get; set; }
        public bool WriteUp { get; set; }
        public bool ManagerTurnOver { get; set; }
        public bool AfterMarketTurnOver { get; set; }
        public bool FinanceTurnOver { get; set; }
        public bool Desking { get; set; }
        public bool Custom1 { get; set; }
        public bool Custom2 { get; set; }
        public bool Custom3 { get; set; }
        public bool Custom4 { get; set; }
        public bool Custom5 { get; set; }
        public bool Custom6 { get; set; }
        public bool Custom7 { get; set; }
        public bool DeletedFlag { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
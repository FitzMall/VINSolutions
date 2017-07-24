using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class CustomerModel
    {

        public long DealerID { get; set; }
        public long CustomerID { get; set; }
        public string CustomerType { get; set; }
        public string CustomerStatus { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerMiddleName { get; set; }
        public string CustomerLastName { get; set; }
        public string CompanyName { get; set; }
        public string SalesMgrUserID { get; set; }
        public string SalesRepUserID { get; set; }
        public string SplitSalesRepUserID { get; set; }
        public string BDAgentUserID { get; set; }
        public string CSIAgentUserID { get; set; }
        public string IsSalesCustomer { get; set; }
        public string IsServiceCustomer { get; set; }
        public string LastInboundContactUTCDate { get; set; }
        public string LastOutboundContactUTCDate { get; set; }
        public string PostalCode { get; set; }
        public string DayTimePhone { get; set; }
        public string DayTimePhoneExt { get; set; }
        public string EveningPhone { get; set; }
        public string EveningPhoneExt { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string DoNotMail { get; set; }
        public string CanBeMailed { get; set; }
        public string DoNotCall { get; set; }
        public string CanBeCalled { get; set; }
        public string DoNotEmail { get; set; }
        public string CanBeEmailed { get; set; }
        public string EBR { get; set; }
        public string EBRSource { get; set; }
        public string EBRDate { get; set; }
        public string EBRExpiration { get; set; }
        public string ExpressConsent { get; set; }
        public string ExpressConsentSource { get; set; }
        public string CompliancePreferredEmail { get; set; }
        public string ExpressConsentLastModifiedUTCDate { get; set; }
        public string ExpressConsentLastModifiedByUser { get; set; }
        public string CanText { get; set; }
        public DateTime CreatedUTCDate { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
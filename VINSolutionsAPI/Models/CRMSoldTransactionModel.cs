using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class CRMSoldTransactionModel
    {
        public string DealerID { get; set; }
        public string CustomerID { get; set; }
        public string LeadID { get; set; }
        public string DealNumber { get; set; }
        public string SalesRepUserID { get; set; }
        public string SplitSaleWithUserID { get; set; }
        public string InventoryType { get; set; }
        public string StockNumber { get; set; }
        public string VIN { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SalePrice { get; set; }
        public string FrontGross { get; set; }
        public string BackGross { get; set; }
        public string TotalGross { get; set; }
        public string PaymentMethod { get; set; }
        public string LeadFinanceSourceID { get; set; }
        public string DownPayment { get; set; }
        public string MonthlyPayment { get; set; }
        public string PaymentTermMonths { get; set; }
        public string FinanceMgrUserID { get; set; }
        public string FinanceCompanyName { get; set; }
        public string GAP { get; set; }
        public string CreditLife { get; set; }
        public string CreditDisability { get; set; }
        public string ExtendedWarranty { get; set; }
        public string CarCare { get; set; }
        public string RoadHazard { get; set; }
        public string FinanceReserve { get; set; }
        public string FinanceIncome { get; set; }
        public string ASIncome { get; set; }
        public string CRMDMSMatchInd { get; set; }
        public string RecordStatusCode { get; set; }
        public string OwnershipCode { get; set; }
        public string SoldUTCDate { get; set; }
        public string CreatedByUserID { get; set; }
        public string CreatedUTCDate { get; set; }
        public string LastUpdatedByUserID { get; set; }
        public string LastUpdatedUTCDate { get; set; }
    }
}
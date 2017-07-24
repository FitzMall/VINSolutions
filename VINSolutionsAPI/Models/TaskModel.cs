using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VINSolutionsAPI.Models
{
    public class TaskModel
    {
        public long DealerID { get; set; }
        public long CustomerID { get; set; }
        public long TaskID { get; set; }
        public string LeadID { get; set; }
        public DateTime TaskCreatedUTCDate { get; set; }
        public string TaskStatusCode { get; set; }
        public string TaskStatus { get; set; }
        public string DueUTCDate { get; set; }
        public string TaskUserTypeCode { get; set; }
        public string TaskUserTypeDescription { get; set; }
        public string TaskTypeID { get; set; }
        public string TaskTypeDescription { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsImportant { get; set; }
        public bool IsUserGenerated { get; set; }
        public string ProcessTypeID { get; set; }
        public string ProcessType { get; set; }
        public string ProcessSubTypeID { get; set; }
        public string ProcessSubType { get; set; }
        public string RepairOrderID { get; set; }
        public string MissedUserID { get; set; }
        public string DismissedUserID { get; set; }
        public string AssignedToUserID { get; set; }
        public DateTime LastUpdatedUTCDate { get; set; }
    }
}
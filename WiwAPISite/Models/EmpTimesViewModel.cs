using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using WiwAPISite.DAL;
using WiwAPISite;
using NLog;
using DapperORM;

namespace WiwAPISite.Models
{
    public class EmpTimesViewModel
    {
        public string storeLoc { get; set; }
        public List<storeLoc> storeLocs { get; set; } 


        public string selectedDept { get; set; }
        public List<locDept> locDepts { get; set; }



       // public string[] SelectedBrands { get; set; }


        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }
         
        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }
        public  List<EmpTime>  EmpHourlist{ get; set; }

        public EmpTimesViewModel()
        {
        }
    }

    public class EmpTime
    {  
        public string Loc { get; set; }
        public string Dept { get; set; }
        public string DAT { get; set; }
        public string EMPName { get; set; }
        public string EMPCode { get; set; }

        public decimal REYHours { get; set; }
        public decimal WIWHours { get; set; }

        public decimal ReytotalHours { get; set; }
        public decimal WIWTotalHours { get; set; }
        public decimal HourVariance { get; set; }

        public string PUNCH_IN { get; set; }
        public string MEAL_OUT { get; set; }
        public string MEAL_IN { get; set; }
        public string PUNCH_OUT { get; set; }

        public string Sch_Start { get; set; }
        public string Sch_End { get; set; }



        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

        public List<EmpTime> getEmpSumHours(DateTime start, DateTime end, string loc, string depts)
        {

            //
            try
            {

                // var rtList = new List<StyleIncentives>();

                string st = "usp_RPT_EMPWorkHours";

                 var p = new DynamicParameters();
                  p.Add("startDate", start);
                  p.Add("endDate", end);
                  p.Add("loc", loc);
                  p.Add("depts", depts);


                List<EmpTime> rs = SqlMapperUtil.StoredProcWithParams<EmpTime>(st, p, mycon196);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "getInvOnFitzMall" + " --usp_UCRPT_DashboradCols Call Failed -- " + exp.ToString());
                return null;
            }

        }

        public List<EmpTime> getEmpDetailHours(DateTime? start, DateTime? end, string EmpCode)
        {

            //
            try
            {


                string st = "usp_RPT_EMPWorkHours_detail";

                var p = new DynamicParameters();
                p.Add("startDate", start);
                p.Add("endDate", end);
                p.Add("EMPCODE", EmpCode);


                List<EmpTime> rs = SqlMapperUtil.StoredProcWithParams<EmpTime>(st, p, mycon196);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "getInvOnFitzMall" + " --usp_UCRPT_DashboradCols Call Failed -- " + exp.ToString());
                return null;
            }

        }
    }
   
    public class storeLoc
    {
        public int RowID { get; set; }
        public string Loc { get; set; }
        public string LocName { get; set; }


        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

        public List<storeLoc> getStoreLocs()
        {
            try
            {

                string st = "usp_RPT_LocList";

                var p = new DynamicParameters();

                List<storeLoc> rs = SqlMapperUtil.StoredProcWithParams<storeLoc>(st, null, mycon196);
                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "getStoreLocs" + " -- getStoreLocs Failed -- " + exp.ToString());
                return null;

            }
        }
    }

    public class locDept
    {
        public int RowID { get; set; }
        public int deptId { get; set; }
        public string deptName { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

     
       public List<locDept> getLocDeptObjs(string storeLoc)
        {
            try
            {

                string st = "usp_RPT_LocDeptListObj";

                var p = new DynamicParameters();
                p.Add("Loc", storeLoc);

                List<locDept> rs = SqlMapperUtil.StoredProcWithParams<locDept>(st, p, mycon196);
                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0: s}", System.DateTime.Now) + " -- " + "getLocDepts" + " -- getLocDepts Failed -- " + exp.ToString());
                return null;

            }
        }
    }
}
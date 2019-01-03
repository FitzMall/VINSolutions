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
using System.ComponentModel.DataAnnotations.Schema;

namespace WiwAPISite.Models
{
    public class EmpTimesViewModel
    {
        public string storeLoc { get; set; }
        public List<storeLoc> storeLocs { get; set; }


        public string selectedDept { get; set; }
        public List<locDept> locDepts { get; set; }


        [NotMapped]
        public string[] SelectedDepts { get; set; }


        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }


        public DateTime preSD1 { get; set; }
        public DateTime preED1 { get; set; }
        public bool incpreSD1 { get; set; }


        public DateTime preSD2 { get; set; }     
        public DateTime preED2 { get; set; }
        public bool incpreSD2 { get; set; }


        public DateTime preSD3 { get; set; }
        public DateTime preED3 { get; set; }
        public bool incpreSD3 { get; set; }

        public List<EmpTime> EmpHourlist { get; set; }

       // public List<empExTime> EmpExHourlist { get; set; }

        public List<EmpTimePPSum> DeptPPHourlist { get; set; }

        public EmpTimesViewModel()
        {
        }
    }

    public class EmpTimePPSum
    {
        public DateTime Pstart { get; set; }
        public DateTime Pend { get; set; }

        public decimal ReytotalHours_SUM { get; set; }
        public decimal WIWtotalHours_SUM { get; set; }
        public decimal HourVariance_SUM { get; set; }
    }


    public class EmpPPeriod
    {

        public int ID { get; set; }
        public DateTime PPStart { get; set; }
        public DateTime PPEnd { get; set; }
        public DateTime LastPayEnd { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

        public EmpPPeriod getLastPayEnd()
        {

            try
            {
                // var rtList = new List<StyleIncentives>();

                string st = "usp_RPT_GetLastPayEndDay";

                List<EmpPPeriod> rs = SqlMapperUtil.StoredProcWithParams<EmpPPeriod>(st, null, mycon196);

                return rs.FirstOrDefault();
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return null;
            }


         
        }

        public int addLastPayEnd(DateTime mylastEnd)
        {
            try
            {
                // var rtList = new List<StyleIncentives>();

                string st = "usp_RPT_AddLastPayEnd";

                var p = new DynamicParameters();

                p.Add("lasPayEnd", mylastEnd);

                // List<EmpPPeriod> rs = SqlMapperUtil.StoredProcWithParams<EmpPPeriod>(st, p, mycon196);
                var i = SqlMapperUtil.InsertUpdateOrDeleteStoredProc(st, p, mycon196);

                return i;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return 0;
            }

        }
            /*
             * 
             [ID]
          ,[PPStart]
          ,[PPEnd]
          ,[LastPayEnd]
             */
        }

        public class EmpTime
    {
        public DateTime Pstart { get; set; }
        public DateTime Pend { get; set; }

        public string Loc { get; set; }

        public string DeptId { get; set; }

        public string Dept { get; set; }
        public string DAT { get; set; }
        public string DAT2 { get; set; }

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

        public string PUNCH_REASON { get; set; }

        public string Sch_Start { get; set; }
        public string Sch_End { get; set; }

        public string MgrComment { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

        //   public List<EmpTime> getEmpSumHours(DateTime start, DateTime end, DateTime presd1, DateTime preed1, DateTime presd2, DateTime preed2, DateTime presd3, DateTime preed3,  string loc, string depts)
        public List<EmpTime> getEmpSumHours(EmpTimesViewModel fvm)
        {

            //
            try
            {

                // var rtList = new List<StyleIncentives>();

                string st = "usp_RPT_EMPWorkHours_MPeriods";

                var p = new DynamicParameters();
                p.Add("startDate", fvm.StartDate);
                p.Add("endDate", fvm.EndDate);


                if (fvm.incpreSD1)
                {
                    p.Add("preSD1", fvm.preSD1);
                    p.Add("preED1", fvm.preED1);
                }

                if (fvm.incpreSD2)
                {
                    p.Add("preSD2", fvm.preSD2);
                    p.Add("preED2", fvm.preED2);
                }
               
                if(fvm.incpreSD3)
                {
                    p.Add("preSD3", fvm.preSD3);
                    p.Add("preED3", fvm.preED3);
                }
               

                p.Add("loc", fvm.storeLoc);
                p.Add("depts", fvm.selectedDept);

               // sds.Split(',')
                List<EmpTime> rs = SqlMapperUtil.StoredProcWithParams<EmpTime>(st, p, mycon196);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return null;
            }

        }


        public List<EmpTimePPSum> getPPSumHours(EmpTimesViewModel fvm)
        {

            //
            try
            {

                // var rtList = new List<StyleIncentives>();

                string st = "usp_RPT_EMPWorkHours_MPeriods_SUM";

                var p = new DynamicParameters();
                p.Add("startDate", fvm.StartDate);
                p.Add("endDate", fvm.EndDate);


                if (fvm.incpreSD1)
                {
                    p.Add("preSD1", fvm.preSD1);
                    p.Add("preED1", fvm.preED1);
                }

                if (fvm.incpreSD2)
                {
                    p.Add("preSD2", fvm.preSD2);
                    p.Add("preED2", fvm.preED2);
                }

                if (fvm.incpreSD3)
                {
                    p.Add("preSD3", fvm.preSD3);
                    p.Add("preED3", fvm.preED3);
                }


                p.Add("loc", fvm.storeLoc);
                p.Add("depts", fvm.selectedDept);

                // sds.Split(',')
                List<EmpTimePPSum> rs = SqlMapperUtil.StoredProcWithParams<EmpTimePPSum>(st, p, mycon196);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return null;
            }

        }


        public List<EmpTime> getEmpDetailHours(DateTime? start, DateTime? end, string EmpCode, string EmpDeptId)
        {

            //
            try
            {
                string st = "usp_RPT_EMPWorkHours_detail";

                var p = new DynamicParameters();
                p.Add("startDate", start);
                p.Add("endDate", end);
                p.Add("EMPCODE", EmpCode);
                p.Add("EmpDeptId", EmpDeptId);


                List<EmpTime> rs = SqlMapperUtil.StoredProcWithParams<EmpTime>(st, p, mycon196);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours_detail" + " --getEmpDetailHours Call Failed -- " + exp.ToString());
                return null;
            }

        }

        //public List<empExTime> getEmpDetailHoursEx(DateTime? start, DateTime? end, string EmpCode, string EmpDeptId)
        //{

        //    //
        //    try
        //    {
        //        string st = "usp_RPT_EMPWorkHours_detail_Ex";

        //        var p = new DynamicParameters();
        //        p.Add("startDate", start);
        //        p.Add("endDate", end);
        //        p.Add("EMPCODE", EmpCode);
        //        p.Add("EmpDeptId", EmpDeptId);


        //        List<empExTime> rs = SqlMapperUtil.StoredProcWithParams<empExTime>(st, p, mycon196);

        //        return rs;
        //    }
        //    catch (Exception exp)
        //    {
        //        logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_EMPWorkHours_detail_Ex" + " --getEmpDetailHoursEx Call Failed -- " + exp.ToString());
        //        return null;
        //    }

        //}
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
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_LocList" + " -- getStoreLocs Failed -- " + exp.ToString());
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
                logger.Error(String.Format("{0: s}", System.DateTime.Now) + " -- " + "usp==usp_RPT_LocDeptListObj" + " -- getLocDeptObjs Failed -- " + exp.ToString());
                return null;

            }
        }
    }

    //public class empExTime
    //{
    //    //public string Loc { get; set; }
    //    //public string DeptId { get; set; }
    //    //public string Dept { get; set; }
    //    public string EMPCode { get; set; }
    //    public string EMPName { get; set; }
    //    public string DAT { get; set; }


    //    public string Sch_Start { get; set; }
    //    public string PUNCH_IN { get; set; }
    //    public string MEAL_OUT { get; set; }
    //    public string MEAL_IN { get; set; }
    //    public string PUNCH_OUT { get; set; }

       

    //    public string Sch_End { get; set; }

    //    public decimal REYHours { get; set; }
    //    public decimal WIWHours { get; set; }

    //    // public decimal ReytotalHours { get; set; }
    //    // public decimal WIWTotalHours { get; set; }
    //    public decimal HourVariance { get; set; }
    //    public string MgrComment { get; set; }

    //}

    public class MgrComment
    {
        //public string ID { get; set; }
        public string EmpCode { get; set; }
        public string DAT { get; set; }
        public string FrmId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public string CommentedBy { get; set; }



        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon196 = ConfigurationManager.ConnectionStrings["DB196"].ConnectionString;

        public int saveUserComment(MgrComment dataObj)
        {

            //
            try
            {
                string usp = "usp_web_SaveComments";

                var p = new DynamicParameters();

                p.Add("EmpCode", dataObj.EmpCode);
                p.Add("DAT", dataObj.DAT);
                p.Add("FrmId", dataObj.FrmId);
                p.Add("Comment", dataObj.Comment);
                p.Add("CommentedBy", dataObj.CommentedBy);
                var cnt = SqlMapperUtil.InsertUpdateOrDeleteStoredProc(usp, p, mycon196);
                return cnt;

            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp===usp_web_SaveComments" + " -- saveUserComment Failed -- " + exp.ToString());
                return 0;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiwAPISite.Models;
using System.Globalization;
using WiwAPISite.Helper;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NLog;
using System.Web.SessionState;

namespace WiwAPISite.Controllers
{
    public class ReportController : Controller
    {
       
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();


        // GET: Report string startDate, string endDate,
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(string login, EmpTimesViewModel fvm)
        {
           
            DateTime mySdate;
            DateTime myEdate;

            var vm = new EmpTimesViewModel();

            //dropdowns
            string storeLoc = Request.Form["storeLoc"];
            if (String.IsNullOrEmpty(storeLoc) || storeLoc == "ALL")
            {
                storeLoc = "ALL";
                ViewBag.storeLoc= "ALL";
            }
            else
            {
                ViewBag.storeLoc = storeLoc;             
            }
            vm.storeLocs = new storeLoc().getStoreLocs();


            //dropdowns
            string locD = Request.Form["selectedDept"];
            if (String.IsNullOrEmpty(locD) || locD == "ALL")
            {
                locD = "ALL";
                ViewBag.selectedDept = "ALL";
            }
            else
            {
                ViewBag.selectedDept = locD;      
            }
            vm.locDepts = new locDept().getLocDeptObjs(storeLoc);

            //post action
            if (Request.RequestType == "POST")
            {
                // var StartDate = Request.Form["StartDate"];
                // var EndDate = Request.Form["EndDate"];

           
                SessionVar.SetString("StartDate", Request.Form["StartDate"]);
                SessionVar.SetString("EndDate", Request.Form["EndDate"]);

                SessionVar.SetString("preSD1", Request.Form["preSD1"]);
                SessionVar.SetString("preED1", Request.Form["preED1"]);

               // var preSD2 = Request.Form["preSD2"];
               // var preED2 = Request.Form["preED2"];

                SessionVar.SetString("preSD2", Request.Form["preSD2"]);
                SessionVar.SetString("preED2", Request.Form["preED2"]);

              //  var preSD3 = Request.Form["preSD3"];
              //  var preED3 = Request.Form["preED3"];

                SessionVar.SetString("preSD3", Request.Form["preSD3"]);
                SessionVar.SetString("preED3", Request.Form["preED3"]);

                var incpreSD1 = Request.Form["incpreSD1"];
                var incpreSD2 = Request.Form["incpreSD2"];
                var incpreSD3 = Request.Form["incpreSD3"];


                SessionVar.SetString("incpreSD1", fvm.incpreSD1.ToString());
                SessionVar.SetString("incpreSD2", fvm.incpreSD2.ToString());
                SessionVar.SetString("incpreSD3", fvm.incpreSD3.ToString());


                ViewBag.UserId = Request.Form["UserId"];
                SessionVar.SetString("UserId", Request.Form["UserId"]);

                ViewBag.LastPY = Request.Form["LastPY"];
                SessionVar.SetString("LastPY", Request.Form["LastPY"]);

                ViewBag.LastPM = Request.Form["LastPM"];
                SessionVar.SetString("LastPM", Request.Form["LastPM"]);

                ViewBag.LastPD = Request.Form["LastPD"];
                SessionVar.SetString("LastPD", Request.Form["LastPD"]);

                //ViewBag.startDate = String.Format("{0:d}", StartDate);
                //ViewBag.endDate = String.Format("{0:d}", EndDate);

                //if (StartDate != null)
                //    vm.StartDate = Convert.ToDateTime(StartDate);

                //if (EndDate != null)
                //    vm.EndDate = Convert.ToDateTime(EndDate);


                ViewBag.startDate = String.Format("{0:d}", fvm.StartDate);
                ViewBag.endDate = String.Format("{0:d}", fvm.EndDate);

                vm.StartDate = fvm.StartDate;
                vm.EndDate = fvm.EndDate;


                vm.storeLoc = storeLoc;
                // vm.selectedDept = Request.Form["selectedDept"];
                vm.selectedDept = fvm.selectedDept;


                var sds = Request.Form["SelectedDepts"];

                SessionVar.SetString("storeLoc", Request.Form["storeLoc"]);
                SessionVar.SetString("selectedDept", Request.Form["selectedDept"]);
                SessionVar.SetString("SelectedDepts", Request.Form["SelectedDepts"]);

                //vm.EmpHourlist = new EmpTime().getEmpSumHours(vm.StartDate, vm.EndDate, vm.storeLoc, vm.selectedDept);
                //vm.EmpHourlist = new EmpTime().getEmpSumHours(fvm.StartDate, fvm.EndDate, fvm.preSD1, fvm.preED1, fvm.preSD2, vm.preED2, vm.preSD3, vm.preED3, vm.storeLoc, sds);
                vm.EmpHourlist = new EmpTime().getEmpSumHours(fvm);
                //
                vm.DeptPPHourlist = new EmpTime().getPPSumHours(fvm);
                
                //ViewBag.SelectedDepts =  sds.Split(',');
                if (sds != null)
                {
                  vm.SelectedDepts = sds.Split(',');
                  ViewBag.SelectedDepts = sds.Split(',');
                }
               

                if (vm.EmpHourlist.Count == 0) 
                ViewBag.ResultTitle = "No data found!";
                else
                {
                    // ViewBag.ResultTitle = "Associate time report for store " + Request.Form["storeLoc"] + ", department " + Request.Form["selectedDept"] + " from " + Request.Form["StartDate"] + " to " + Request.Form["EndDate"];
                    // ViewBag.ResultTitle2 =  " From:"   +   Request.Form["StartDate"] + " to " + Request.Form["EndDate"];
                    ViewBag.ResultTitle = "";
                }
               
            }
            else
            { //get action
                if (Request.QueryString["FD"] == "1")
                {

                    try
                    {
                        vm.StartDate = DateTime.ParseExact(SessionVar.GetString("StartDate"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        vm.EndDate = DateTime.ParseExact(SessionVar.GetString("EndDate"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        // get other fields from session
                        //vm.incpreSD1 =  //SessionVar.GetString("incpreSD1");
                        vm.preSD1 = DateTime.ParseExact(SessionVar.GetString("preSD1"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        vm.preED1 = DateTime.ParseExact(SessionVar.GetString("preED1"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        vm.preSD2 = DateTime.ParseExact(SessionVar.GetString("preSD2"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        vm.preED2 = DateTime.ParseExact(SessionVar.GetString("preED2"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        vm.preSD3 = DateTime.ParseExact(SessionVar.GetString("preSD3"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        vm.preED3 = DateTime.ParseExact(SessionVar.GetString("preED3"), "yyyy-MM-dd", CultureInfo.InvariantCulture);


                        vm.incpreSD1 = Boolean.Parse(SessionVar.GetString("incpreSD1"));
                        vm.incpreSD2 = Boolean.Parse(SessionVar.GetString("incpreSD2"));
                        vm.incpreSD3 = Boolean.Parse(SessionVar.GetString("incpreSD3"));

                        vm.storeLoc = SessionVar.GetString("storeLoc");
                        vm.selectedDept = SessionVar.GetString("selectedDept");

                        //
                        vm.locDepts = new locDept().getLocDeptObjs(vm.storeLoc);
                        vm.SelectedDepts = SessionVar.GetString("SelectedDepts").Split(',').ToArray();


                        //return to prviouse selection
                        ViewBag.storeLoc = SessionVar.GetString("storeLoc");
                        ViewBag.selectedDept = SessionVar.GetString("selectedDept");

                        ViewBag.startDate = vm.StartDate;  // mySdate;
                        ViewBag.endDate = vm.EndDate;     // myEdate;

                        //vm.EmpHourlist = new EmpTime().getEmpSumHours(mySdate, myEdate, vm.storeLoc, SessionVar.GetString("SelectedDepts"));
                        //vm.EmpHourlist = new EmpTime().getEmpSumHours(mySdate, myEdate, vm.preSD1, vm.preED1, vm.preSD2, vm.preED2, vm.preSD3, vm.preED3, vm.storeLoc, SessionVar.GetString("SelectedDepts"));
                        //ViewBag.ResultTitle = "Associate time report for store " + vm.storeLoc + ", department " + vm.selectedDept + " from " + mySdate + " to " + myEdate;
                        vm.EmpHourlist = new EmpTime().getEmpSumHours(vm);
                        vm.DeptPPHourlist = new EmpTime().getPPSumHours(vm);


                        ViewBag.ResultTitle = "";
                        ViewBag.UserId = SessionVar.GetString("UserId");
                        ViewBag.LastPY = SessionVar.GetString("LastPY");
                        ViewBag.LastPM = SessionVar.GetString("LastPM");
                        ViewBag.LastPD = SessionVar.GetString("LastPD");

                    }
                    catch (Exception exp)
                    {
                        logger.Info(String.Format("{0:s}", System.DateTime.Now) + exp.ToString());
                        //return View("SessionOut");
                        //redirect to default page                     
                        return RedirectToAction("Index","Report");
                    }

                }
                else
                {   //firsttime get here
                    logger.Info(String.Format("{0:s}", System.DateTime.Now) + "====Report View Started:====");

                    //get lastpayend date from db...                 
                    var lastPayEnd = new EmpPPeriod().getLastPayEnd();
                    DateTime lastPDate = lastPayEnd.LastPayEnd;

                    //ViewBag.LastPayEnd = lastPDate;
                    ViewBag.LastPY = lastPDate.Year;
                    ViewBag.LastPM = lastPDate.Month;
                    ViewBag.LastPD = lastPDate.Day;

                    vm.EmpHourlist = null;
                    ViewBag.UserId = login;
                    SessionVar.SetString("UserId", login);
                }
            }
            logger.Info(String.Format("{0:s}", System.DateTime.Now) + "Report View Started:====" + ViewBag.UserId);
            return View(vm);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult HourDetails(string empDeptId, string empCode, string start, string end, string login)
        {
            DateTime mySdate;
            DateTime myEdate;
            var myempCode = string.Empty;
            if (string.IsNullOrEmpty(start)  && string.IsNullOrEmpty(end))
            {
                myEdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                mySdate = myEdate.AddDays(-14);
            }
            else
            {
                mySdate = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture); //mySdate;
                myEdate = DateTime.ParseExact(end, "yyyy-MM-dd", CultureInfo.InvariantCulture); // myEdate;
            }

            if (string.IsNullOrEmpty(empCode))
            {
                return View("ErrorEmpCode");
            }

            //SessionVar.GetString("UserId");         
            if (String.IsNullOrEmpty(login))
            { 
                ViewBag.UserId = SessionVar.GetString("UserId");
            }
            else
            {
                ViewBag.UserId = login;
            }

            ViewBag.startDate = start;
            ViewBag.endDate = end;

            ViewBag.empDeptId = empDeptId;
            ViewBag.empCode = empCode;


            var vm = new EmpTimesViewModel();
            vm.EmpHourlist = new EmpTime().getEmpDetailHours(mySdate, myEdate, empCode, empDeptId);

            logger.Info(String.Format("{0:s}", System.DateTime.Now) + "HourDetails Report:" + ViewBag.UserId);
            return View(vm);
        }

        //export to excel
        //public ActionResult ExportToExcel(string empDept, string empCode, string start, string end)
        //{

        //    DateTime mySdate;
        //    DateTime myEdate;        
        //    if (string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
        //    {
        //        myEdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //        mySdate = myEdate.AddDays(-14);
        //    }
        //    else
        //    {
        //        mySdate = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture); //mySdate;
        //        myEdate = DateTime.ParseExact(end, "yyyy-MM-dd", CultureInfo.InvariantCulture); // myEdate;
        //    }
        //    var vm = new EmpTimesViewModel();
        //    vm.EmpExHourlist = new EmpTime().getEmpDetailHoursEx(mySdate, myEdate, empCode, empDept);


        //    var grid = new GridView();
        //    grid.DataSource = vm.EmpExHourlist;
        //    grid.DataBind();

        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=EmployeeHours_" + empCode + ".xls");
        //    Response.ContentType = "application/ms-excel";

        //    Response.Charset = "";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);

        //    grid.RenderControl(htw);

        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();

        //    return View("ExportToExcel");

        //}



        //public ActionResult PrintDetailHours(string empDept, string empCode, string start, string end)
        //{

        //    DateTime mySdate;
        //    DateTime myEdate;
        //    var myempCode = string.Empty;
        //    if (string.IsNullOrEmpty(start) && string.IsNullOrEmpty(end))
        //    {
        //        myEdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //        mySdate = myEdate.AddDays(-14);
        //    }
        //    else
        //    {
        //        mySdate = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture); //mySdate;
        //        myEdate = DateTime.ParseExact(end, "yyyy-MM-dd", CultureInfo.InvariantCulture); // myEdate;
        //    }

        //    if (string.IsNullOrEmpty(empCode))
        //    {
        //        return View("ErrorEmpCode");
        //    }

        //    //SessionVar.GetString("UserId");
        //    ViewBag.userId = SessionVar.GetString("UserId");

        //    ViewBag.startDate = start;
        //    ViewBag.endDate = end;

        //    ViewBag.empDeptId = empDept;
        //    ViewBag.empCode = empCode;


        //    var vm = new EmpTimesViewModel();
        //    vm.EmpHourlist = new EmpTime().getEmpDetailHours(mySdate, myEdate, empCode, empDept);
        //    return View(vm);
          

        //}
        
        
        //ajax to refresh dept list
        public JsonResult getDeptsForLoc(string storeLoc)
        {
            // var dept = new locDept().getLocDepts(storeLoc);
            // return Json(new { data = dept }, JsonRequestBehavior.AllowGet);
          /*  var depts = new locDept().getLocDeptObjs(storeLoc);
            List<string> list = new List<string>();

            foreach (locDept item in depts)
            {
                list.Add(item.deptName);
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

            */

             return Json(new locDept().getLocDeptObjs(storeLoc), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveComments(List<MgrComment> frmComments)
        {

            int successUpd = 0;
     
            foreach (var MgrComment in frmComments)
            {
                try
                {
                    MgrComment dbtbl = new MgrComment();
                    successUpd = dbtbl.saveUserComment(MgrComment);

                }
                catch (Exception ex)
                {
                    logger.Error("SaveComments failed" + ex.Message);
                }
            }

            var ret = new List<string>();
            if (successUpd == -1)
                ret.Add("Comments were saved successfully!");
            else
                ret.Add("save failed");

            return Json(ret);
            // var dept = new locDept().getLocDepts(storeLoc);
            // return Json(new { data = dept }, JsonRequestBehavior.AllowGet);           
            // return Json(new locDept().getLocDeptObjs(storeLoc), JsonRequestBehavior.AllowGet);
        }
    }
}
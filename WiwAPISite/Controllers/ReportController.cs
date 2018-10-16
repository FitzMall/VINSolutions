using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiwAPISite.Models;
using System.Globalization;
using WiwAPISite.Helper;

namespace WiwAPISite.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(string startDate, string endDate, string login="lish")
        {
            DateTime mySdate;
            DateTime myEdate;
            ViewBag.userId = login;
           
            SessionVar.SetString("UserId", login );
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
            string locD = Request.Form["locDept"];
            if (String.IsNullOrEmpty(locD) || locD == "ALL")
            {
                locD = "ALL";
                ViewBag.locDept = "ALL";
            }
            else
            {
                ViewBag.locDept = locD;      
            }
            vm.locDepts = new locDept().getLocDeptObjs(storeLoc);

            //post action
            if (Request.RequestType == "POST")
            {
                var StartDate = Request.Form["StartDate"];
                var EndDate = Request.Form["EndDate"];
                ViewBag.userId = Request.Form["UserId"];
                SessionVar.SetString("UserId", Request.Form["UserId"]);

                ViewBag.startDate = String.Format("{0:d}", StartDate);  
                ViewBag.endDate = String.Format("{0:d}", EndDate); 

                if (StartDate != null)
                    vm.StartDate = Convert.ToDateTime(StartDate);

                if (EndDate != null)
                    vm.EndDate = Convert.ToDateTime(EndDate);

                vm.storeLoc = storeLoc;
                vm.locDept = locD;

                SessionVar.SetString("storeLoc", Request.Form["storeLoc"]);
                SessionVar.SetString("locDept", Request.Form["locDept"]);

                vm.EmpHourlist = new EmpTime().getEmpSumHours(vm.StartDate, vm.EndDate, vm.storeLoc, vm.locDept);

                if (vm.EmpHourlist.Count == 0) 
                ViewBag.ResultTitle = "No data found!";
                else
                {
                    ViewBag.ResultTitle = "Associate time report for store " + Request.Form["storeLoc"] + ", department " + Request.Form["locDept"] + " from " + Request.Form["StartDate"] + " to " + Request.Form["EndDate"];
                    // ViewBag.ResultTitle2 =  " From:"   +   Request.Form["StartDate"] + " to " + Request.Form["EndDate"];
                }
               
            }
            else
            { //get action
                if (Request.QueryString["FD"] == "1")
                {
                    if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
                    {
                        myEdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        mySdate = myEdate.AddDays(-14);
                    }
                    else
                    {
                        mySdate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        myEdate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    // vm.EmpHourlist = null;
                    vm.StartDate = mySdate;
                    vm.EndDate = myEdate;

                    vm.storeLoc = SessionVar.GetString("storeLoc");
                    vm.locDept = SessionVar.GetString("locDept");

                    //return to prviouse selection
                    ViewBag.storeLoc = SessionVar.GetString("storeLoc");
                    ViewBag.locDept = SessionVar.GetString("locDept");
                    ViewBag.startDate = mySdate;
                    ViewBag.endDate = myEdate;

                    vm.EmpHourlist = new EmpTime().getEmpSumHours(mySdate, myEdate, vm.storeLoc, vm.locDept);

                    ViewBag.ResultTitle = "Associate time report for store " + vm.storeLoc + ", department " + vm.locDept  + " from " + mySdate + " to " + myEdate;

                }
                else
                {  //firsttime get th
                    vm.EmpHourlist = null;
                }
            }
            
            return View(vm);
        }



        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult HourDetails(string loc, string empCode, string start, string end)
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
                //  myempCode = "05/0190698";
                //  empCode = myempCode;
                return View("ErrorEmpCode");
            }

            //SessionVar.GetString("UserId");
            ViewBag.userId  = SessionVar.GetString("UserId");

            ViewBag.startDate = start;
            ViewBag.endDate = end;
            var vm = new EmpTimesViewModel();
            vm.EmpHourlist = new EmpTime().getEmpDetailHours(mySdate, myEdate, empCode); 
            return View(vm);
        }

        public JsonResult getDeptsForLoc(string storeLoc)
        {
            // var dept = new locDept().getLocDepts(storeLoc);
            // return Json(new { data = dept }, JsonRequestBehavior.AllowGet);
            var depts = new locDept().getLocDeptObjs(storeLoc);

            List<string> list = new List<string>();

            foreach (locDept item in depts)
            {
                list.Add(item.deptName);
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            // return Json(new locDept().getLocDeptObjs(storeLoc), JsonRequestBehavior.AllowGet);
        }
    }
}
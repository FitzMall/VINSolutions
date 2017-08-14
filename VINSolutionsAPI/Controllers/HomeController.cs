using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using System.Globalization;


namespace VINSolutionsAPI.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index(string bkdays)
        {
            return View();
        }
        public JsonResult Appointment(string bkdays)
        {

            //var dealers = Business.APIHelper.GetDealers();
            //var success = Business.SQLQueries.InsertOrUpdateDealers(dealers);

            //var users = Business.APIHelper.GetUsers();
            //var success = Business.SQLQueries.InsertOrUpdateUsers(users);

            //var users = Business.APIHelper.GetUserAccess();
            //var success = Business.SQLQueries.InsertOrUpdateUserAccess(users);

            //var startDate = new DateTime(2010, 1, 1);
            //var endDate = new DateTime(2016,12,31);

            ////var leadSource = Business.APIHelper.GetLeadSource(startDate, endDate,"");
            ////var success = Business.SQLQueries.InsertOrUpdateLeadSource(leadSource);

            //var leadStatus = Business.APIHelper.GetLeadStatus(startDate, endDate, "");
            //var success1 = Business.SQLQueries.InsertOrUpdateLeadStatus(leadStatus);

            //var leadStatusCustom = Business.APIHelper.GetLeadStatusCustom(startDate, endDate, "");
            //var success2 = Business.SQLQueries.InsertOrUpdateLeadStatusCustom(leadStatusCustom);

            var errorMessages = "";
            int numberofdays = 1;
            if (!string.IsNullOrEmpty(bkdays))
            {
                numberofdays = Convert.ToInt32(bkdays);
            }

            var dataDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-numberofdays);

            // var dataDate = new DateTime(2017,7,04);
            // var dataDate = new DateTime("2017-07-26");
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var startDate = new DateTime();
            startDate = endDate.AddDays(-1);

            var bContinue = true;
            var runCount = 0;

            Logger.Info("Daily Load Start..." + DateTime.Now);
            Logger.Info("Load data appointment=>> start" + DateTime.Now);

            do
            {
                if (endDate > dataDate)
                {
                    var appointments = Business.APIHelper.GetAppointments(startDate, endDate, ref errorMessages);

                    if (appointments != null && appointments.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateAppointment(appointments, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                        }

                    }
                    else
                    {
                        //bContinue = false;
                    }
                    endDate = startDate;
                    startDate = endDate.AddDays(-1);
                    runCount += 1;

                }
                else
                {
                    bContinue = false;
                }


            } while (bContinue);
            Logger.Info("Load data appointment=>> end" + DateTime.Now);

            return Json("Success", JsonRequestBehavior.AllowGet);

        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityname">examples: appointment;crmsold;customer;dmssold;lead;inventory;leadtradeinv;leadvofinterest;
        /// servicevisit;sroomvisit;task
        /// dealer;user;useraccess; leadsource; leadstatus;leadstatuscustom
        /// </param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public JsonResult getvindata(string entityname, string sdate, string edate)
        {
            var errorMessages = "";
            Int32 numberofDays;
            DateTime mySdate;
            DateTime myEdate;
            //regular load one day data
            if (string.IsNullOrEmpty(sdate) && string.IsNullOrEmpty(edate))
            {
                var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var startDate = new DateTime();
                startDate = endDate.AddDays(-1);
                //load yesterday data...
                Logger.Info("Load data started: " + DateTime.Now + " ***entityname***=" + entityname);
                Business.APIHelper.makePull(entityname, startDate, endDate);
                Logger.Info("Load data finish: " + DateTime.Now);
                return Json("Success!", JsonRequestBehavior.AllowGet);
            }

            try
            {
                 mySdate = DateTime.ParseExact(sdate, "yyyyMMdd", CultureInfo.InvariantCulture);
                 myEdate = DateTime.ParseExact(edate, "yyyyMMdd", CultureInfo.InvariantCulture);
                 numberofDays = Convert.ToInt32((myEdate - mySdate).TotalDays);
            }
            catch (Exception ex)
            {
               // Logger.Info("Load data Task=>> end: " + DateTime.Now);
                return Json("Date Format must be yyyyMMdd", JsonRequestBehavior.AllowGet);
            }

            if (numberofDays < 0 )
            {
                return Json("Start date must be before end date! No Data was loaded", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Logger.Info("Load data started: " + DateTime.Now + " ***entityname***=" + entityname);
                if (numberofDays < 14 )
                {
                    ////just pass the startdate and end date to vin api
                    Business.APIHelper.makePull(entityname, mySdate, myEdate);
                    //Business.APIHelper.makePull("appointment", mySdate, myEdate);
                    //Business.APIHelper.makePull("crmsold", mySdate, myEdate);
                    //Business.APIHelper.makePull("customer", mySdate, myEdate);
                    //Business.APIHelper.makePull("dmssold", mySdate, myEdate);
                    //Business.APIHelper.makePull("inventory", mySdate, myEdate);
                    //Business.APIHelper.makePull("leadtradeinv", mySdate, myEdate);
                    //Business.APIHelper.makePull("leadvofinterest", mySdate, myEdate);
                    //Business.APIHelper.makePull("servicevisit", mySdate, myEdate);
                    //Business.APIHelper.makePull("sroomvisit", mySdate, myEdate);

                }
                else
                {
                    Int32 div = numberofDays / 10;
                    Int32 mod = numberofDays % 10;

                    for (int i=0; i<div; i++)
                    {
                        //api call by calculate date
                        mySdate = myEdate.AddDays(-10);
                        Business.APIHelper.makePull(entityname, mySdate, myEdate);
                        //Business.APIHelper.makePull("appointment", mySdate, myEdate);
                        //Business.APIHelper.makePull("crmsold", mySdate, myEdate);
                        //Business.APIHelper.makePull("customer", mySdate, myEdate);
                        //Business.APIHelper.makePull("dmssold", mySdate, myEdate);
                        //Business.APIHelper.makePull("inventory", mySdate, myEdate);
                        //Business.APIHelper.makePull("leadtradeinv", mySdate, myEdate);
                        //Business.APIHelper.makePull("leadvofinterest", mySdate, myEdate);
                        //Business.APIHelper.makePull("servicevisit", mySdate, myEdate);
                        // Business.APIHelper.makePull("sroomvisit", mySdate, myEdate);
                        myEdate = mySdate;
                    }

                   if (mod>0)
                    {
                        mySdate = myEdate.AddDays(-mod);
                        Business.APIHelper.makePull(entityname, mySdate, myEdate);
                        //Business.APIHelper.makePull("appointment", mySdate, myEdate);
                        //Business.APIHelper.makePull("crmsold", mySdate, myEdate);
                        //Business.APIHelper.makePull("customer", mySdate, myEdate);
                        //Business.APIHelper.makePull("dmssold", mySdate, myEdate);
                        //Business.APIHelper.makePull("inventory", mySdate, myEdate);
                        //Business.APIHelper.makePull("leadtradeinv", mySdate, myEdate);
                        //Business.APIHelper.makePull("leadvofinterest", mySdate, myEdate);
                        //Business.APIHelper.makePull("servicevisit", mySdate, myEdate);
                        //Business.APIHelper.makePull("sroomvisit", mySdate, myEdate);
                    }
                }
            }
      
            Logger.Info("Load data end=>> end: " + DateTime.Now);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VINSolutionsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

            var dataDate = new DateTime(2017,5,31);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var startDate = new DateTime();
            startDate = endDate.AddDays(-1);

            var bContinue = true;
            var runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var appointments = Business.APIHelper.GetAppointments(startDate, endDate, ref errorMessages);
            //        if (appointments != null && appointments.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateAppointment(appointments, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }

            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;

            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var transactions = Business.APIHelper.GetCRMSoldTransactions(startDate, endDate, ref errorMessages);

            //        if (transactions != null && transactions.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateCRMSoldTransaction(transactions, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }

            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var transactions = Business.APIHelper.GetDMSSoldTransactions(startDate, endDate, ref errorMessages);
            //        if (transactions != null && transactions.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateDMSSoldTransaction(transactions, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }

            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //var missedDates = string.Empty;
            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var customers = Business.APIHelper.GetCustomers(startDate, endDate, ref errorMessages);
            //        if (customers != null && customers.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateCustomer(customers, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }

            //        }
            //        else
            //        {
            //            missedDates += endDate + ",";
            //        }

            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);

            
            endDate = new DateTime(2017,6,29);
            startDate = new DateTime(2017,6,23);
            //startDate = endDate.AddDays(-1);
            bContinue = true;
            runCount = 0;

            do
            {
                if (endDate > startDate)
                {
                    var inventory = Business.APIHelper.GetInventory(startDate, endDate, ref errorMessages);
                    if (inventory != null && inventory.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateInventory(inventory, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                        }

                    }
                    else
                    {
                        //missedDates += endDate + ",";
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


            ////GET ALL THE LEAD DATA


            //missedDates = string.Empty;

            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var leads = Business.APIHelper.GetLeads(startDate, endDate, ref errorMessages);

            //        if (leads != null && leads.Count() > 0)
            //        {

            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateLead(leads, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }
            //        }
            //        else
            //        {
            //            missedDates += endDate + ",";
            //        }

            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;


            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var vehicles = Business.APIHelper.GetLeadTradeInVehicles(startDate, endDate, ref errorMessages);
            //        if (vehicles != null && vehicles.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateLeadTradeInVehicle(vehicles, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }

            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;

            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var vehicles = Business.APIHelper.GetLeadVehicleOfInterest(startDate, endDate, ref errorMessages);
            //        if (vehicles != null && vehicles.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateLeadVehicleOfInterest(vehicles, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }
            //        }
            //        else
            //        {
            //            missedDates += endDate + ",";
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;


            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var visits = Business.APIHelper.GetServiceVisit(startDate, endDate, ref errorMessages);
            //        if (visits != null && visits.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateServiceVisit(visits, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }
            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }

            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;

            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);

            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;


            //do
            //{
            //    if (endDate > dataDate)
            //    {
            //        var visits = Business.APIHelper.GetShowroomVisit(startDate, endDate, ref errorMessages);
            //        if (visits != null && visits.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateShowroomVisit(visits, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }
            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);


            //endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //startDate = new DateTime();
            //startDate = endDate.AddDays(-1);
            //bContinue = true;
            //runCount = 0;


            //do
            //{
            //    if (endDate > dataDate)
            //    {

            //        var tasks = Business.APIHelper.GetTasks(startDate, endDate, ref errorMessages);
            //        if (tasks != null && tasks.Count() > 0)
            //        {
            //            try
            //            {
            //                var success = Business.SQLQueries.InsertOrUpdateTask(tasks, ref errorMessages);
            //            }
            //            catch (Exception ex)
            //            {
            //                var error = ex.Message;
            //            }
            //        }
            //        else
            //        {
            //            //bContinue = false;
            //        }
            //        endDate = startDate;
            //        startDate = endDate.AddDays(-1);
            //        runCount += 1;
            //    }
            //    else
            //    {
            //        bContinue = false;
            //    }


            //} while (bContinue);

            //What does errorMessages hold?

            return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using RestSharp;
using WiwAPISite.Models;
using System.Configuration;
using WIWAPISite.Mailers;
using Newtonsoft.Json;
using WiwAPISite.DAL;
using System.Globalization;

namespace WiwAPISite.Controllers
{
    public class HomeController : Controller
    {
        private static UserMailer uMailer = new UserMailer();
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static string WIWBaseURL = ConfigurationManager.AppSettings["WIWAPIBaseURL"].ToString();
        public static string WIWAPIKey = ConfigurationManager.AppSettings["WIWAPIKey"].ToString();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getWIWData(string startDate, string endDate)
        {
            Logger.Info("=========" + DateTime.Now + "=========");
            Logger.Info("Load WIW data =>> start:" + DateTime.Now);

            DateTime mySdate;
            DateTime myEdate;
            if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                myEdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                mySdate = myEdate.AddDays(-7);
            }
            else
            {
                try
                {
                    mySdate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    myEdate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }
                catch(Exception ex)
                {
                    return Json("Date string must be in a valid format!", JsonRequestBehavior.AllowGet);
                }
            }          

            string rt = "Success";
            var mytoken = getLoginToken();

            rt = getWIWLocs(mytoken);
            rt = getWIWSites(mytoken);           
            rt = getWIWUsers(mytoken);
            rt = getWIWShifts(mytoken, mySdate, myEdate);

            //test code 
            Logger.Info("Load WIW data=>> end:" + DateTime.Now);
            return Json(rt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getlocations()
        {

            Logger.Info("Load location data=>> start:" + DateTime.Now);
            string rt = string.Empty;
            var mytoken = getLoginToken();
            try
            {        
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL + "/locations");
                
                request.Method = Method.GET;

                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);

                var response = client.Execute(request);
                // var response = client.Execute<List<WiwLocation>>(request);
                RootLocation items = JsonConvert.DeserializeObject<RootLocation>(response.Content);

                if (response.StatusDescription =="OK")
                 rt = SQLQueries.InsertOrUpdateLocations(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getlocations failed" + ex.Message);
            }

            Logger.Info("Load data location=>> end:" + DateTime.Now);

            return Json(rt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getUsers()
        {
            Logger.Info("Load getUsers data=>> start:" + DateTime.Now);
            string rt = string.Empty;
            var mytoken = getLoginToken();

            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL  + "/users");
                request.Method = Method.GET;
                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);

                var response = client.Execute(request);
         
                RootUser items = JsonConvert.DeserializeObject<RootUser>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateUsers(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getlocations failed" + ex.Message);
            }

            Logger.Info("Load data user=>> end:" + DateTime.Now);

            return Json(rt, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getShifts(DateTime startDate, DateTime endDate)
        {
            Logger.Info("Load Shift data=>> start:" + DateTime.Now);
            string rt = string.Empty;
            var mytoken = getLoginToken();

            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL  + "/shifts");

                request.Method = Method.GET;

                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);
                //request.AddUrlSegment("start", "2018-08-05 00:00:00");
                //request.AddUrlSegment("end", "2018-09-30 23:59:59");


                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + " 00:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + " 23:59:59";

                request.AddParameter("start", startDateFormatted, ParameterType.QueryString);
                request.AddParameter("end", endDateFormatted, ParameterType.QueryString);
                var response = client.Execute(request);
                
                RootShift items = JsonConvert.DeserializeObject<RootShift>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateShifts(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getShifts failed" + ex.Message);
            }

            Logger.Info("Load data Shift=>> end:" + DateTime.Now);

            return Json(rt, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string getLoginToken()
        {

            Logger.Info("Load data =>> start" + DateTime.Now);
            Logger.Info("Do Login =>>" + DateTime.Now);
            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                // client.BaseUrl = new Uri("https://api.wheniwork.com/2/login");
                client.BaseUrl = new Uri(WIWBaseURL + "/login");
                request.Method = Method.POST;

                request.AddHeader("Content-type", "application/json");
                //  request.AddHeader("W-Key", "95f800d6cc12638d81159183ad4b316f6a15c821");
                request.AddHeader("W-Key", WIWAPIKey);
                request.AddJsonBody(
                 new
                 {
                     username = "lis@fitzmall.com",
                     password = "FitzWay099"
                 });
                //client.Execute(request);
                //var response = client.Execute(request);
               var response = client.Execute<Login>(request);
               if (response.StatusDescription == "OK")
                {
                    return response.Data.token;
                }
                else
                {
                    Logger.Error("Error: WIW API Authentication failed:" + response.StatusDescription);
                    return "";                  
                }
            }
            catch (Exception ex)
            {           
                Logger.Error("Error: WIW API Authentication failed:" + ex.ToString());
                uMailer.ApiErrorAlert(ex.ToString()).Send();
                return null;
            }

        }

        private static string getWIWShifts(string mytoken, DateTime startDate, DateTime endDate)
        {

            string rt = "Success";
            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL + "/shifts");

                request.Method = Method.GET;

                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);
                //request.AddUrlSegment("start", "2018-08-05 00:00:00");
                //request.AddUrlSegment("end", "2018-09-30 23:59:59");


                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + " 00:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + " 23:59:59";

                request.AddParameter("start", startDateFormatted, ParameterType.QueryString);
                request.AddParameter("end", endDateFormatted, ParameterType.QueryString);
                var response = client.Execute(request);

                RootShift items = JsonConvert.DeserializeObject<RootShift>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateShifts(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getShifts failed" + ex.Message);
            }
            Logger.Info("Load data Shifts=>> end:" + DateTime.Now);
            return rt;

        }

        private static string getWIWUsers(string mytoken)
        {
            string rt = "Success";

            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL + "/users");
                request.Method = Method.GET;
                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);

                var response = client.Execute(request);

                RootUser items = JsonConvert.DeserializeObject<RootUser>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateUsers(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getWIWUsers failed" + ex.Message);
            }


            Logger.Info("Load data Users=>> end:" + DateTime.Now);
            return rt;
        }

        private static string getWIWLocs(string mytoken)
        {
            string rt = "Success";
            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL + "/locations");

                request.Method = Method.GET;

                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);

                var response = client.Execute(request);
                // var response = client.Execute<List<WiwLocation>>(request);
                RootLocation items = JsonConvert.DeserializeObject<RootLocation>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateLocations(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getWIWLocs failed" + ex.Message);
            }

            Logger.Info("Load data location=>> end:" + DateTime.Now);
            return rt;
        }

        private static string getWIWSites(string mytoken)
        {
            string rt = "Success";
            try
            {
                var client = new RestClient();
                RestRequest request = new RestRequest();
                client.BaseUrl = new Uri(WIWBaseURL + "/sites");

                request.Method = Method.GET;

                request.AddHeader("Content-type", "application/json");
                request.AddHeader("W-Token", mytoken);

                var response = client.Execute(request);
                // var response = client.Execute<List<WiwLocation>>(request);
                RootSite items = JsonConvert.DeserializeObject<RootSite>(response.Content);

                if (response.StatusDescription == "OK")
                    rt = SQLQueries.InsertOrUpdateSites(items);

            }
            catch (Exception ex)
            {
                Logger.Error("getWIWSites failed" + ex.Message);
            }

            Logger.Info("Load data site=>> end:" + DateTime.Now);
            return rt;
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
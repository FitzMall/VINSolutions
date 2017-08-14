using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using VINSolutionsAPI.Models;
using NLog;


namespace VINSolutionsAPI.Business
{
    public class APIHelper
    {

        public static string VINSolutionsBaseURL = ConfigurationManager.AppSettings["VINSolutionsBaseURL"].ToString();
        public static string VINSolutionsAPIKey = ConfigurationManager.AppSettings["VINSolutionsAPIKey"].ToString();

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static IEnumerable<AppointmentModel> GetAppointments(DateTime startDate, DateTime endDate, ref string errorMessage)
        {

            try
            {
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Appointment/1.0");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var returnModels = response.Content.ReadAsAsync<IEnumerable<AppointmentModel>>().Result;
                    return returnModels;
                }
                else
                {
                    errorMessage = errorMessage + "Appointments API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin Api Call failed:" + errorMessage );
                  
                }             

                return null;
            }
            catch(Exception ex)
            {
                errorMessage = errorMessage + "Appointments API - " + ex.Message + "/n";
                Logger.Error("Error: Appointments API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<CRMSoldTransactionModel> GetCRMSoldTransactions(DateTime startDate, DateTime endDate, ref string errorMessage)
        {

            try
            {
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/CRMSoldTransaction/1.0");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var returnModels = response.Content.ReadAsAsync<IEnumerable<CRMSoldTransactionModel>>().Result;
                    return returnModels;
                }
                else
                {
                    errorMessage = errorMessage + "CRMSoldTransactions API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin Api Call failed:" + errorMessage);
                }

                return null;
            }
            catch(Exception ex)
            {
                errorMessage = errorMessage + "CRMSoldTransactions API - " + ex.Message + "/n";
                Logger.Error("Error: CRMSoldTransactions API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<CustomerModel> GetCustomers(DateTime startDate, DateTime endDate, ref string errorMessage)
        {

            try
            { 
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
                //var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Customer/1.0");

                    //client.DefaultRequestHeaders.AcceptCharset.Add()
                    // Add an Accept header for JSON format.     
                client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));               

                // List data response.
                HttpResponseMessage response = new HttpResponseMessage();
                response.Headers.Add("charset", "utf-8");
                response = client.GetAsync(urlParameters).Result;  // Blocking call!

                response.Content.Headers.ContentType.CharSet = "utf-8";
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    string jsonString = response.Content.ReadAsStringAsync().Result;                  
                    var returnModels = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(jsonString);
                  
                    return returnModels;
                }
                else
                {
                    errorMessage = errorMessage + "Customer API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin Api Call failed:" + errorMessage);
                }
                return null;

            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Customer API - " + ex.InnerException + "/n";
                return null;
            }

        }

        public static IEnumerable<DealerModel> GetDealers()
        {
            try {
                    var urlParameters = "?api_key=" + VINSolutionsAPIKey; //+ "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Dealer/1.0");

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    // List data response.
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body. Blocking!
                        var returnModels = response.Content.ReadAsAsync<IEnumerable<DealerModel>>().Result;
                        return returnModels;
                    }
                }
                catch (Exception ex)
                {
               
                    Logger.Error("Error: Dealer API failed:" + ex.Message);
                    return null;
                }

            return null;

        }

        public static IEnumerable<DMSSoldTransactionModel> GetDMSSoldTransactions(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/DMSSoldTransaction/1.0");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body. Blocking!
                        var returnModels = response.Content.ReadAsAsync<IEnumerable<DMSSoldTransactionModel>>().Result;
                        return returnModels;
                    }
                    else
                    {
                        errorMessage = errorMessage + "DMSSoldTransaction API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                        Logger.Error("Error***" + DateTime.Now);
                        Logger.Error("Error: Vin Api Call failed:" + errorMessage);
                    }
                    return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "DMSSoldTransaction API - " + ex.Message + "/n";
                Logger.Error("Error: DMSSoldTransaction API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<InventoryModel> GetInventory(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            {
                //var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T00:00:00";
                // var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T00:00:00";
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Inventory/1.0");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var returnModels = response.Content.ReadAsAsync<IEnumerable<InventoryModel>>().Result;
                    return returnModels;
                }
                else
                {
                        errorMessage = errorMessage + "Inventory API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                        Logger.Error("Error***" + DateTime.Now);
                        Logger.Error("Error: Vin Api Call failed:" + errorMessage);
                }
                    return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Inventory API - " + ex.Message + "/n";
                Logger.Error("Error: Inventory API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<LeadModel> GetLeads(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            //var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Lead/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadModel>>().Result;
                return returnModels;
            }
                else
                {
                    errorMessage = errorMessage + "Leads API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin Lead Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Leads API - " + ex.Message + "/n";
                Logger.Error("Error: Lead API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<LeadStatusModel> GetLeadStatus(DateTime startDate, DateTime endDate, string dealerIDs)
        {

            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/LeadStatus/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadStatusModel>>().Result;
                return returnModels;
            }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<LeadStatusCustomModel> GetLeadStatusCustom(DateTime startDate, DateTime endDate, string dealerIDs)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;            
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/LeadStatusCustom/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadStatusCustomModel>>().Result;
                return returnModels;
            }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<LeadSourceModel> GetLeadSource(DateTime startDate, DateTime endDate, string dealerIDs)
        {
            try
            { 
                var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
                var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
                //LastUpdatedStartUTC=2016-12-18T12:00:00

                var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(VINSolutionsBaseURL + "/LeadSource/1.0");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    //var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadSourceModel>>().Result;
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    var returnModels = JsonConvert.DeserializeObject<IEnumerable<LeadSourceModel>>(jsonString);

                   // return returnModels;

                    return returnModels;
                }
                else
                {
                   // errorMessage = errorMessage + "Inventory API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin LeadSource Api Call failed:" + response.StatusCode.ToString());
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.Error("Error: LeadSource API failed:" + ex.Message);
                return null;
            }
        }

        public static IEnumerable<LeadTradeInVehicleModel> GetLeadTradeInVehicles(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/LeadTradeInVehicle/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadTradeInVehicleModel>>().Result;
                    return returnModels;
                }
                else
                {
                    errorMessage = errorMessage + "LeadTradeInVehicles API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin LeadTradeInVehicles Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "LeadTradeInVehicles API - " + ex.Message + "/n";
                Logger.Error("Error: LeadTradeInVehicles API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<LeadVehicleOfInterestModel> GetLeadVehicleOfInterest(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            //var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/LeadVehicleOfInterest/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadVehicleOfInterestModel>>().Result;
                    return returnModels;
                }
                else
                {
                    errorMessage = errorMessage + "LeadVehicleOfInterest API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin LeadTradeInVehicles Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "LeadVehicleOfInterest API - " + ex.Message + "/n";
                Logger.Error("Error: LeadVehicleOfInterest API failed:" + errorMessage);
                return null;
            }
        }

        public static IEnumerable<ServiceVisitModel> GetServiceVisit(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/ServiceVisit/1.0");            

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<ServiceVisitModel>>().Result;
                return returnModels;
            }
                else
                {
                    errorMessage = errorMessage + "ServiceVisit API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin ServiceVisit Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "ServiceVisit API - " + ex.Message + "/n"; 
                Logger.Error("Error: ServiceVisit API failed:" + errorMessage);

                return null;
            }
        }

        public static IEnumerable<ShowroomVisitModel> GetShowroomVisit(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/ShowroomVisit/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<ShowroomVisitModel>>().Result;
                return returnModels;
            }
                else
                {
                    errorMessage = errorMessage + "ShowroomVisit API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin ShowroomVisit Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "ShowroomVisit API - " + ex.Message + "/n";
                Logger.Error("Error: ShowroomVisit API failed:" + errorMessage);

                return null;
            }
        }

        public static IEnumerable<TaskModel> GetTasks(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T12:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T12:00:00";
            //LastUpdatedStartUTC=2016-12-18T12:00:00

            var urlParameters = "?api_key=" + VINSolutionsAPIKey + "&LastUpdatedStartUTC=" + startDateFormatted + "&LastUpdatedEndUTC=" + endDateFormatted;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/Task/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<TaskModel>>().Result;
                return returnModels;
            }
                else
                {
                    errorMessage = errorMessage + "Task API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                    Logger.Error("Error***" + DateTime.Now);
                    Logger.Error("Error: Vin Task Api Call failed:" + errorMessage);
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Task API - " + ex.Message + "/n";
               
                Logger.Error("Error: Task API failed:" + errorMessage);

                return null;
            }
        }

        public static IEnumerable<UserModel> GetUsers()
        {

            var urlParameters = "?api_key=" + VINSolutionsAPIKey; // + "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/User/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<UserModel>>().Result;
                return returnModels;
            }

            return null;

        }

        public static IEnumerable<UserAccessModel> GetUserAccess()
        {

            var urlParameters = "?api_key=" + VINSolutionsAPIKey; // + "&LastUpdatedStartUTC=" + startDate.ToUniversalTime() + "&LastUpdatedEndUTC=" + endDate.ToUniversalTime();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VINSolutionsBaseURL + "/UserAccess/1.0");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var returnModels = response.Content.ReadAsAsync<IEnumerable<UserAccessModel>>().Result;
                return returnModels;
            }

            return null;

        }

        public static void makePull(string entityName, DateTime sdate, DateTime edate)
        {
            var errorMessages = "";

            switch (entityName.ToLower())
            {
                case "appointment":
                    var appointments = Business.APIHelper.GetAppointments(sdate, edate, ref errorMessages);
                    if (appointments != null && appointments.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateAppointment(appointments, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateAppointment failed:" + errorMessages);
                        }
                    }
                    break;
                case "crmsold":
                    var transactions = Business.APIHelper.GetCRMSoldTransactions(sdate, edate, ref errorMessages);
                    if (transactions != null && transactions.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateCRMSoldTransaction(transactions, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateCRMSoldTransaction failed:" + errorMessages);
                        }

                    }
                    break;
                case "customer":
                    var customers = Business.APIHelper.GetCustomers(sdate, edate, ref errorMessages);
                    if (customers != null && customers.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateCustomer(customers, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateCustomer failed:" + errorMessages);
                        }

                    }
                    break;
                case "dealer":
                    var dealers = Business.APIHelper.GetDealers();
                    if (dealers != null && dealers.Count() > 0)
                    {
                        var success = Business.SQLQueries.InsertOrUpdateDealers(dealers);
                    }
                    break;

                case "dmssold":

                    var DMStransactions = Business.APIHelper.GetDMSSoldTransactions(sdate, edate, ref errorMessages);
                    if (DMStransactions != null && DMStransactions.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateDMSSoldTransaction(DMStransactions, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateDMSSoldTransaction failed:" + errorMessages);
                        }

                    }
                    break;
                case "lead":
                    var leads = Business.APIHelper.GetLeads(sdate, edate, ref errorMessages);
                    if (leads != null && leads.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateLead(leads, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLead failed:" + errorMessages);
                        }
                    }
                    break;
                case "inventory":
                    var inventory = Business.APIHelper.GetInventory(sdate, edate, ref errorMessages);
                    if (inventory != null && inventory.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateInventory(inventory, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateInventory failed:" + errorMessages);
                        }
                    }

                    break;
                case "leadtradeinv":
                  
                    var vehicles = Business.APIHelper.GetLeadTradeInVehicles(sdate, edate, ref errorMessages);
                    if (vehicles != null && vehicles.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateLeadTradeInVehicle(vehicles, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLeadTradeInVehicle failed:" + errorMessages);
                        }

                    }
                    break;
                case "leadvofinterest":

                    var vehinterests = Business.APIHelper.GetLeadVehicleOfInterest(sdate, edate, ref errorMessages);
                    if (vehinterests != null && vehinterests.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateLeadVehicleOfInterest(vehinterests, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLeadVehicleOfInterest failed:" + errorMessages);
                        }
                    }
                    break;
                case "task":
                    var tasks = Business.APIHelper.GetTasks(sdate, edate, ref errorMessages);
                    if (tasks != null && tasks.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateTask(tasks, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateTask failed:" + errorMessages);
                        }
                    }
                    break;
                case "servicevisit":
                    var visits = Business.APIHelper.GetServiceVisit(sdate, edate, ref errorMessages);
                    if (visits != null && visits.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateServiceVisit(visits, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateServiceVisit failed:" + errorMessages);
                        }
                    }

                    break;
                case "sroomvisit":
                    var srvisits = Business.APIHelper.GetShowroomVisit(sdate, edate, ref errorMessages);
                    if (srvisits != null && srvisits.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateShowroomVisit(srvisits, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateShowroomVisit failed:" + errorMessages);
                        }
                    }
                    break;
                case "user":
                    var users1 = Business.APIHelper.GetUsers();
                    if (users1 != null && users1.Count() > 0)
                    {
                        try
                        {
                            var success1 = Business.SQLQueries.InsertOrUpdateUsers(users1);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateUsers failed:" + errorMessages);
                        }
                    }
                    break;
                case "useraccess":
                    var users2 = Business.APIHelper.GetUserAccess();
                    if (users2 != null && users2.Count() > 0)
                    {
                        try
                        {
                            var success2 = Business.SQLQueries.InsertOrUpdateUserAccess(users2);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateUserAccess failed:" + errorMessages);
                        }                        
                    }
                    break;
                case "leadsource":
                    var leadSource = Business.APIHelper.GetLeadSource(sdate, edate, "");
                    if (leadSource != null && leadSource.Count() > 0)
                    {
                        try
                        {
                            var success = Business.SQLQueries.InsertOrUpdateLeadSource(leadSource, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLeadSource failed:" + errorMessages);
                        }                     
                    }                      
                    break;
                case "leadstatus":

                    var leadStatus = Business.APIHelper.GetLeadStatus(sdate, edate, "");
                    if (leadStatus != null && leadStatus.Count() > 0)
                    {
                        try
                        {
                            var success1 = Business.SQLQueries.InsertOrUpdateLeadStatus(leadStatus, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLeadStatus failed:" + errorMessages);
                        }                    
                    }

                    break;
                case "leadstatuscustom":
                    var leadStatusCustom = Business.APIHelper.GetLeadStatusCustom(sdate, edate, "");

                    if (leadStatusCustom != null && leadStatusCustom.Count() > 0)
                    {
                        try
                        {
                            var success2 = Business.SQLQueries.InsertOrUpdateLeadStatusCustom(leadStatusCustom, ref errorMessages);
                        }
                        catch (Exception ex)
                        {
                            var error = ex.Message;
                            Logger.Error("Error: InsertOrUpdateLeadStatusCustom failed:" + errorMessages);
                        }                     
                    }
                    break;
                default:
                    //no data loaded
                    break;
            }       
       }
    }
}
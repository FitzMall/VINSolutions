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

namespace VINSolutionsAPI.Business
{
    public class APIHelper
    {

        public static string VINSolutionsBaseURL = ConfigurationManager.AppSettings["VINSolutionsBaseURL"].ToString();
        public static string VINSolutionsAPIKey = ConfigurationManager.AppSettings["VINSolutionsAPIKey"].ToString();

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
                }
                

                return null;
            }
            catch(Exception ex)
            {
                errorMessage = errorMessage + "Appointments API - " + ex.Message + "/n";
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
                }

                return null;
            }
            catch(Exception ex)
            {
                errorMessage = errorMessage + "CRMSoldTransactions API - " + ex.Message + "/n";
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

                //var returnModels = response.Content.ReadAsAsync<IEnumerable<CustomerModel>>().Result;

                    var returnModels = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(jsonString);

                    return returnModels;
            }
                else
                {
                    errorMessage = errorMessage + "Customer API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "DMSSoldTransaction API - " + ex.Message + "/n";
                return null;
            }
        }

        public static IEnumerable<InventoryModel> GetInventory(DateTime startDate, DateTime endDate, ref string errorMessage)
        {
            try
            { 
            var startDateFormatted = startDate.Year + "-" + startDate.Month.ToString("00") + "-" + startDate.Day.ToString("00") + "T00:00:00";
            var endDateFormatted = endDate.Year + "-" + endDate.Month.ToString("00") + "-" + endDate.Day.ToString("00") + "T00:00:00";
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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Inventory API - " + ex.Message + "/n";

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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Leads API - " + ex.Message + "/n";

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
                var returnModels = response.Content.ReadAsAsync<IEnumerable<LeadSourceModel>>().Result;
                return returnModels;
            }

                return null;
            }
            catch (Exception ex)
            {
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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "LeadTradeInVehicles API - " + ex.Message + "/n";

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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "LeadVehicleOfInterest API - " + ex.Message + "/n";

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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "ServiceVisit API - " + ex.Message + "/n";

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
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "ShowroomVisit API - " + ex.Message + "/n";

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
                    errorMessage = errorMessage + "Tasks API - " + startDateFormatted + ":" + endDateFormatted + ":" + response.StatusCode.ToString() + "/n";
                }
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Tasks API - " + ex.Message + "/n";

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

    }
}
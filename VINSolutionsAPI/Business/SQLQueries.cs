using System;
using System.Collections.Generic;
using VINSolutionsAPI.Models;
using NLog;

namespace VINSolutionsAPI.Business
{
    public class SQLQueries
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static bool InsertOrUpdateDealers(IEnumerable<DealerModel> dealers)
        {
            var bSuccess = true;

            foreach (var dealer in dealers)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Dealer]", dealer);
                }
                catch (Exception ex)
                {
                   
                    Logger.Error("InsertOrUpdateDealers failed" + ex.Message);
                    bSuccess = false;
                }
               
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateUsers(IEnumerable<UserModel> users)
        {
            var bSuccess = true;

            foreach (var user in users)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_User]", user);
                }
                catch (Exception ex)
                {

                    Logger.Error("InsertOrUpdateUsers failed" + ex.Message);
                    bSuccess = false;
                }

                //var existingUser = SqlMapperUtil.SqlWithParams<UserModel>("Select * from [dbo].[User] where UserID = @UserID", new { UserID = user.UserID }, "JJFServer");

                //if (existingUser.Count == 0)
                //{
                //    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[User] VALUES(@UserID,@FirstName,@LastName,@RecordStatusCode,@LastClockInUTCDate,@LastClockOutUTCDate,@LastMobileLoginDLTDate, @LastBrowserLoginDLTDate, @LastUpdatedUTCDate)",
                //        new
                //        {
                //            UserID = user.UserID,
                //            FirstName = user.FirstName,
                //            LastName = user.LastName,
                //            RecordStatusCode = user.RecordStatusCode,
                //            LastClockInUTCDate = user.LastClockInUTCDate,
                //            LastClockOutUTCDate = user.LastClockOutUTCDate,
                //            LastMobileLoginDLTDate = user.LastMobileLoginDLTDate,
                //            LastBrowserLoginDLTDate = user.LastBrowserLoginDLTDate,
                //            LastUpdatedUTCDate = user.LastUpdatedUTCDate
                //        }, "JJFServer");
                //}
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateUserAccess(IEnumerable<UserAccessModel> users)
        {
            var bSuccess = true;

            foreach (var user in users)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_UserAccess]", user);
                }
                catch (Exception ex)
                {

                    Logger.Error("InsertOrUpdateUserAccess failed" + ex.Message);
                    bSuccess = false;
                }

            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadSource(IEnumerable<LeadSourceModel> leadSource, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var source in leadSource)
            {

                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_LeadSource]", source);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadSource DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLeadSource failed" + ex.Message);
                    bSuccess = false;
                }

                //SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[LeadSource] VALUES (@DealerID,@LeadSourceID,@LeadTypeID,@LeadSourceName,@LeadSourceTypeName,@LeadSourceGroupName,@LastUpdatedUTCDate)",
                //        new
                //        {
                //            DealerID = source.DealerID,
                //            LeadSourceID = source.LeadSourceID,
                //            LeadTypeID = source.LeadTypeID,
                //            LeadSourceName = source.LeadSourceName,
                //            LeadSourceTypeName = source.LeadSourceTypeName,
                //            LeadSourceGroupName = source.LeadSourceGroupName,
                //            LastUpdatedUTCDate = source.LastUpdatedUTCDate,                            
                //        }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadStatus(IEnumerable<LeadStatusModel> leadStatus, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var status in leadStatus)
            {


                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_LeadStatus]", status);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadStatus DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLeadStatus failed" + ex.Message);
                    bSuccess = false;
                }

            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadStatusCustom(IEnumerable<LeadStatusCustomModel> leadStatus, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var status in leadStatus)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_LeadStatusCustom]", status);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadStatusCustom DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLeadStatusCustom failed" + ex.Message);
                    bSuccess = false;
                }

            }
            return bSuccess;
        }

        public static bool InsertOrUpdateAppointment(IEnumerable<AppointmentModel> appointments, ref string errorMessage)
        {
            var bSuccess = true;
            
            foreach (var appointment in appointments)
            {
                try
                {
                    
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Appointment]", appointment);

                }
                catch (Exception ex)
                {
                    errorMessage = "Appointments DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateAppointment failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateCRMSoldTransaction(IEnumerable<CRMSoldTransactionModel> transactions, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var transaction in transactions)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_CRMSoldTransaction]", transaction);
                  
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "CRMSoldTransaction DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateCRMSoldTransaction failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateDMSSoldTransaction(IEnumerable<DMSSoldTransactionModel> transactions, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var transaction in transactions)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_DMSSoldTransaction]", transaction);
                   
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "DMSSoldTransaction DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateDMSSoldTransaction failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateCustomer(IEnumerable<CustomerModel> customers, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var customer in customers)
            {
                try
                {
                   
                   int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Customer]", customer);
                   
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Customer DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateCustomer failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateInventory(IEnumerable<InventoryModel> inventory, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var vehicle in inventory)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Inventory]", vehicle);
                    
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Inventory DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateInventory failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLead(IEnumerable<LeadModel> leads, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var lead in leads)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Lead]", lead);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Lead DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLead failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }
   
        public static bool InsertOrUpdateLeadTradeInVehicle(IEnumerable<LeadTradeInVehicleModel> vehicles, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var vehicle in vehicles)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_LeadTradeInVehicle]", vehicle);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadTradeInVehicle DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLeadTradeInVehicle failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadVehicleOfInterest(IEnumerable<LeadVehicleOfInterestModel> vehicles, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var vehicle in vehicles)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_LeadVehicleOfInterest]", vehicle);
                   
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadVehicleOfInterest DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateLeadVehicleOfInterest failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateServiceVisit(IEnumerable<ServiceVisitModel> visits, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var visit in visits)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_ServiceVisit]", visit);
                  
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "ServiceVisit DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateServiceVisit failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateShowroomVisit(IEnumerable<ShowroomVisitModel> visits, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var visit in visits)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_ShowroomVisit]", visit);
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "ShowroomVisit DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateShowroomVisit failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess; 
        }

        public static bool InsertOrUpdateTask(IEnumerable<TaskModel> tasks, ref string errorMessage)
        {
            var bSuccess = true;

            foreach (var task in tasks)
            {
                try
                {
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[VINSolutions_API].[dbo].[usp_upsert_Task]", task);
                   
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Task DB - " + ex.Message + "/n";
                    Logger.Error("InsertOrUpdateTask failed" + ex.Message);
                    bSuccess = false;
                }
            }
            return bSuccess;
        }

    }
}
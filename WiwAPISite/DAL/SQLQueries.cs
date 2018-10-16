using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using WiwAPISite.Models;
using WIWAPISite.Mailers;

namespace WiwAPISite.DAL
{
    public class SQLQueries
    {
        private static UserMailer uMailer = new UserMailer();
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static string InsertOrUpdateLocations(RootLocation resp)
        {
            bool bSuccess = true;
            foreach (var location in resp.locations)
            {
                try
                {
                    FitzLocation ftbl = new FitzLocation();
                    ftbl.id = location.id;
                    ftbl.name = location.name;
                    ftbl.address = location.address;
                    ftbl.created_at = location.created_at.ToString();
                    ftbl.updated_at = location.updated_at.ToString();
                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[EMPScheduler].[dbo].[usp_upsert_Location]", ftbl);
                }
                catch (Exception ex)
                {
                    Logger.Error("InsertOrUpdateLocations failed" + ex.Message);
                    uMailer.ApiErrorAlert(ex.ToString()).Send();
                    bSuccess = false;
                }
            }
            if (bSuccess)
            { return "Success"; }
                         
            return "Failed";   
        }


        public static string InsertOrUpdateSites(RootSite resp)
        {
            bool bSuccess = true;
            foreach (var site in resp.sites)
            {
                try
                {
                    FitzSite ftbl = new FitzSite();
                    ftbl.id = site.id;
                    ftbl.account_id = site.account_id;
                    ftbl.location_id = site.location_id;
                    ftbl.name = site.name;
                    ftbl.color = site.color;
                    ftbl.description = site.description;
                    ftbl.address = site.address;
                    ftbl.latitude = site.latitude;
                    ftbl.longitude = site.longitude;
                    ftbl.place_id = site.place_id;
                    ftbl.created_at = site.created_at;
                    ftbl.updated_at = site.updated_at;
                    ftbl.is_deleted = site.is_deleted;
                    ftbl.deleted_at = site.deleted_at;
                    ftbl.radius = site.radius;

                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[EMPScheduler].[dbo].[usp_upsert_Site]", ftbl);
                }
                catch (Exception ex)
                {
                    Logger.Error("InsertOrUpdateSites failed" + ex.Message);
                    uMailer.ApiErrorAlert(ex.ToString()).Send();
                    bSuccess = false;
                }
            }
            if (bSuccess)
            { return "Success"; }

            return "Failed";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static string InsertOrUpdateUsers(RootUser resp)
        {
            bool bSuccess = true;
            foreach (var user in resp.users)
            {
                try
                {
                    FitzUser ftbl = new FitzUser();
                    ftbl.id = user.id;
                    ftbl.account_id = user.account_id;
                    ftbl.login_id = user.login_id;

                    ftbl.role = user.role;
                    ftbl.type = user.type;
                    ftbl.email = user.email;
                    ftbl.first_name = user.first_name;
                    ftbl.last_name = user.last_name;
                    ftbl.phone_number = user.phone_number;
                    ftbl.employee_code = user.employee_code;
                    ftbl.activated = user.activated;
                    ftbl.is_hidden = user.is_hidden;
                    ftbl.uuid = user.uuid;
                    ftbl.notes = user.notes;
                    ftbl.hours_preferred = user.hours_preferred;
                    ftbl.hours_max = user.hours_max;
                    ftbl.hourly_rate = user.hourly_rate;
                    ftbl.reminder_time = user.reminder_time;
                    ftbl.last_login = user.last_login;
                    ftbl.is_deleted = user.is_deleted;
                    ftbl.is_active = user.is_active;
                    ftbl.is_payroll = user.is_payroll;
                    ftbl.is_private = user.is_private;
                    ftbl.dismissed_at = user.dismissed_at;
                    ftbl.notified_at = user.notified_at;
                    ftbl.invited_at = user.invited_at;
                    ftbl.created_at = user.created_at;
                    ftbl.updated_at = user.updated_at;
                    ftbl.deleted_at = user.deleted_at;

                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[EMPScheduler].[dbo].[usp_upsert_User]", ftbl);
                }
                catch (Exception ex)
                {

                    Logger.Error("InsertOrUpdateUsers failed" + ex.Message);
                    uMailer.ApiErrorAlert(ex.ToString()).Send();
                    bSuccess = false;
                }
            }

            if (bSuccess)
            { return "Success"; }

            return "Failed";
        }

        public static string InsertOrUpdateShifts(RootShift resp)
        {
            bool bSuccess = true;
            foreach (var shift in resp.shifts)
            {
                try
                {
                    FitzShift ftbl = new FitzShift();
                    ftbl.id = shift.id;
                    ftbl.account_id = shift.account_id;
                    ftbl.user_id = shift.user_id;
                    ftbl.location_id = shift.location_id;
                    ftbl.position_id = shift.position_id;
                    ftbl.site_id = shift.site_id;

                    ftbl.start_time = shift.start_time;
                    ftbl.end_time = shift.end_time;
                    ftbl.break_time = shift.break_time;
                    ftbl.color = shift.color;
                    ftbl.notes = shift.notes;

                    ftbl.alerted = shift.alerted;
                    ftbl.published = shift.published;
                    ftbl.published_date = shift.published_date;
                    ftbl.notified_at = shift.notified_at;
                    ftbl.created_at = shift.created_at;
                    ftbl.updated_at = shift.updated_at;
                    ftbl.acknowledged = shift.acknowledged;

                    ftbl.acknowledged_at = shift.acknowledged_at;

                    ftbl.creator_id = shift.creator_id;
                    ftbl.is_open = shift.is_open;
                    ftbl.actionable = shift.actionable;

                    int storeProc = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("[EMPScheduler].[dbo].[usp_upsert_Shift]", ftbl);

                }
                catch (Exception ex)
                {
                    Logger.Error("InsertOrUpdateShifts failed" + ex.Message);
                    uMailer.ApiErrorAlert(ex.ToString()).Send();
                    bSuccess = false;
                }
            }
            if (bSuccess)
            { return "Success"; }

            return "Failed";
        }

    }
}
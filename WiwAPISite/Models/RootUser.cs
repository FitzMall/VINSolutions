using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiwAPISite.Models
{
    public class RootUser
    {
        public User[] users { get; set; }
        public Location[] locations { get; set; }
        public Position[] positions { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public int login_id { get; set; }
        public int timezone_id { get; set; }
        public int created_by { get; set; }
        public int role { get; set; }
        public bool is_payroll { get; set; }
        public int is_trusted { get; set; }
        public int type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string employee_code { get; set; }
        public bool activated { get; set; }
        public bool is_hidden { get; set; }
        public string uuid { get; set; }
        public string notes { get; set; }
        public bool is_private { get; set; }
        public float? hours_preferred { get; set; }
        public float? hours_max { get; set; }
        public float? hourly_rate { get; set; }
        public Alert_Settings alert_settings { get; set; }
        public int reminder_time { get; set; }
        public string sleep_start { get; set; }
        public string sleep_end { get; set; }
        public object[] my_positions { get; set; }
        public bool is_onboarded { get; set; }
        public string last_login { get; set; }
        public object hired_on { get; set; }
        public string dismissed_at { get; set; }
        public string notified_at { get; set; }
        public string invited_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public bool is_deleted { get; set; }
        public bool is_active { get; set; }
        public bool password { get; set; }
        public int country_id { get; set; }
        public int c2dm_auth_key { get; set; }
        public int migration_id { get; set; }
        public int affiliate { get; set; }
        public string infotips { get; set; }
        public string timezone_name { get; set; }
        public Avatar avatar { get; set; }
        public int?[] positions { get; set; }
        public int[] locations { get; set; }
        public object position_rates { get; set; }
        public object position_quality { get; set; }
        public Sort sort { get; set; }
        public string country_code { get; set; }
        public bool is_internal_login { get; set; }
    }

    public class FitzUser
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public int login_id { get; set; }     
        public int role { get; set; }   
        public int type { get; set; }

        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string employee_code { get; set; }

        public bool activated { get; set; }
        public bool is_hidden { get; set; }

        public string uuid { get; set; }
        public string notes { get; set; }
       
        public float? hours_preferred { get; set; }
        public float? hours_max { get; set; }
        public float? hourly_rate { get; set; }

        public int reminder_time { get; set; }
        public string last_login { get; set; }

        public bool is_deleted { get; set; }
        public bool is_active { get; set; }
        public bool is_payroll { get; set; }
        public bool is_private { get; set; }

        public string dismissed_at { get; set; }
        public string notified_at { get; set; }
        public string invited_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
     
    }

    public class Alert_Settings
    {
        public Timeoff timeoff { get; set; }
        public Swaps swaps { get; set; }
        public Schedule schedule { get; set; }
        public Reminders reminders { get; set; }
        public Availability availability { get; set; }
        public New_Employee new_employee { get; set; }
        public Attendance attendance { get; set; }
        public Payroll payroll { get; set; }
        public Workchat workchat { get; set; }
        public Ot_Alerts ot_alerts { get; set; }
    }

    public class Timeoff
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Swaps
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Schedule
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Reminders
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Availability
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class New_Employee
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Attendance
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Payroll
    {
        public bool sms { get; set; }
    }

    public class Workchat
    {
        public bool alerts { get; set; }
        public bool badge_icon { get; set; }
        public bool in_app { get; set; }
    }

    public class Ot_Alerts
    {
        public bool sms { get; set; }
        public bool email { get; set; }
    }

    public class Avatar
    {
        public string url { get; set; }
        public string size { get; set; }
    }

    public class Sort
    {
        public int _4329473 { get; set; }
        public int _4315706 { get; set; }
    }

    public class Position
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int sort { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int updated_by { get; set; }
        public bool is_deleted { get; set; }
    }



    //class User
    //{
    //    public int id { get; set; }
    //    public int login_id { get; set; }
    //    public int account_id { get; set; }
    //    public int role { get; set; } //The user's role.
    //                                  //1 = Admin
    //                                  //2 = Manager
    //                                  //3 = Employee(Default)
    //                                  //4 = Lead(Unused)
    //                                  //5 = Supervisor
    //    public string email { get; set; }
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //    public string phone_number { get; set; }
    //    public string employee_code { get; set; }
    //    public bool activated { get; set; }

    //    public string notes { get; set; }
    //    public float hours_preferred { get; set; }
    //    public float hours_max { get; set; }
    //    public float hourly_rate { get; set; }
    //    public bool type { get; set; }
    //    public DateTime last_login { get; set; }

    //    public bool is_deleted { get; set; }
    //    public bool is_hidden { get; set; }
    //    public bool is_payroll { get; set; }
    //    public bool is_private { get; set; }
    //    public bool is_trusted { get; set; }

    //    public List<int> positions { get; set; }
    //    public List<int> locations { get; set; }


    //}

}
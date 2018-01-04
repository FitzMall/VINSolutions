using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Mvc.Mailer;


namespace VInSolutionsAPI.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{

        public UserMailer()
		{
			MasterName="_Layout";
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual MvcMailMessage ApiErrorAlert(string errorMessage)
        {
            ViewBag.Data = errorMessage;

            string mailTo = ConfigurationManager.AppSettings["emailAlert"];
            List<string> myList = mailTo.Split(';').ToList();

            return Populate(x =>
            {
                x.Subject = "VIN API Failed";
                x.ViewName = "ErrorAlert";
                x.IsBodyHtml = true;
                x.Body = errorMessage;

                foreach (var em in myList)
                {
                    x.To.Add(em);
                }
            });
        }

        #region  two default method examples
        /// <summary>
        /// default method
        /// </summary>
        /// <returns></returns>
		public virtual MvcMailMessage PasswordReset()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "PasswordReset";
				x.ViewName = "PasswordReset";
				x.To.Add("some-email@example.com");
			});
        }
        
        #endregion
    }
}
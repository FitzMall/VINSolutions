using System;
using System.Collections.Generic;
using Mvc.Mailer;


namespace WIWAPISite.Mailers
{ 
    public interface IUserMailer
    {
            //MvcMailMessage Welcome(SendEmailModel sm, string fn, string mailTo); 
            //MvcMailMessage ThankYou(SendEmailModel sm, Guid mailTocken );
			MvcMailMessage PasswordReset();
            MvcMailMessage ApiErrorAlert(string msg);
            //MvcMailMessage ApptsMail(string MailTo, string fileName, string fileName2); 
            //MvcMailMessage ApptsMail(string MailTo); 
    }
}
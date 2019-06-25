using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using NLog;
using DapperORM;

namespace WiwAPISite.Models
{
    public class IISLogViewModel
    {
        public List<IISLogFile> Folderlist { get; set; }
        public List<IISLogFile> Accesslist { get; set; }
    }

    public class IISLogFile
    {
        public string wwwRootFolder { get; set; }
        public string accessPath { get; set; }
        public string UserIP { get; set; }
        public string accessDate { get; set; }

        public int hitCnt { get; set; }


        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string mycon190 = ConfigurationManager.ConnectionStrings["DB190"].ConnectionString;

        public List<IISLogFile> getIISFolderRoot()
        {

            try
            {
                string st = "usp_IISLog_Analysis_Root";

                List<IISLogFile> rs = SqlMapperUtil.StoredProcWithParams<IISLogFile>(st, null, mycon190);
               
                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==getIISLogs" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return null;
            }



        }

        public List<IISLogFile> getIISLogsDetail(string folderName)
        {

            try
            {
                string st = "usp_IISLog_Analysis";
                var p = new DynamicParameters();
                p.Add("folderName", folderName);

                List<IISLogFile> rs = SqlMapperUtil.StoredProcWithParams<IISLogFile>(st, p, mycon190);

                return rs;
            }
            catch (Exception exp)
            {
                logger.Error(String.Format("{0:s}", System.DateTime.Now) + " -- " + "usp==getIISLogs" + " --getEmpSumHours Call Failed -- " + exp.ToString());
                return null;
            }



        }


    }
}
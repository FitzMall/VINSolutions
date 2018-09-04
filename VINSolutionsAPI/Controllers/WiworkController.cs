using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using System.Globalization;

namespace VINSolutionsAPI.Controllers
{
    public class WiworkController : Controller
    {

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        // GET: Wiwork
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getWiworkData()
        {
            Logger.Info("get getWiworkData started" + DateTime.Now);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}
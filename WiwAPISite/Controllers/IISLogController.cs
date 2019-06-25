using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiwAPISite.Models;


namespace WiwAPISite.Controllers
{
    public class IISLogController : Controller
    {
        // GET: IISLog
        public ActionResult Index()
        {
            var vm = new IISLogViewModel();
            vm.Folderlist = new IISLogFile().getIISFolderRoot();
          //  vm.Accesslist = new IISLogFile().getIISLogsDetail();

            return View(vm);
        }


        public ActionResult Apath(string fn)
        {
            var vm = new IISLogViewModel();
           // vm.Folderlist = new IISLogFile().getIISFolderRoot();
            vm.Accesslist = new IISLogFile().getIISLogsDetail(fn);

            return View(vm);
        }
    }
} 
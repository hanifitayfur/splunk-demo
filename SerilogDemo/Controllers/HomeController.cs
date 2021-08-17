using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;
using Serilog.Core;
using SerilogDemo.Logger;

namespace SerilogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger = ServiceLocator.Resolve<ILog>();

        public ActionResult Index()
        {
            _logger.Information("Index Page Calling ILog");

            return View();
        }

        public ActionResult About()
        {
            try
            {
                throw new ArgumentException("ArgumentException is null by splunk");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }


            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}

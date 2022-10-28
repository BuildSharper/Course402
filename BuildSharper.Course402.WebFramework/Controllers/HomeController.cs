using BuildSharper.Course402.WebFramework.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSharper.Course402.WebFramework.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ILogService _logService;

        public HomeController(ILogService logService)
        {
            _logService = logService;
        }

        public ActionResult Index()
        {
            _logService.Log("User visited homepage (.NET Framework)");
            return View();
        }

        public ActionResult About()
        {
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
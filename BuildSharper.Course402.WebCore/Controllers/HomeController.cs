using BuildSharper.Course402.WebCore.Models;
using BuildSharper.Course402.WebCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuildSharper.Course402.WebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogService _logService;

        public HomeController(ILogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            _logService.Log("User visited homepage (.NET Core)");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
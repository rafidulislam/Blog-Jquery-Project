using JQ_prj1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JQ_prj1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        [HttpPost]
        public  int add(int val1, int val2)
        {
            return val1 + val2;
        }

        [HttpPost]
        public CalculateInfo Calculate(int val1, int val2)
        {
            CalculateInfo calculateInfo = new CalculateInfo();
            calculateInfo.Add=val1+ val2;
            calculateInfo.Subtract=val1 - val2;
            calculateInfo.Multiply=val1* val2;
            calculateInfo.Divide= val1/ val2;

            return calculateInfo;
        }
    }
}

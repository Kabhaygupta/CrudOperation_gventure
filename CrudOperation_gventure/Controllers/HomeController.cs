using CrudOperation_gventure.Models;
using CrudOperation_gventure.Models.DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudOperation_gventure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {  
            Enrollment _enrollment = new Enrollment();
            return View(_enrollment);
        }


        [HttpPost]
        public IActionResult Index(Enrollment _enrollment)
        {
            DotNetCoreDbContext _dotNetCoreDbContext = new DotNetCoreDbContext();

            var result= _dotNetCoreDbContext.Enrollment.Where(m=>m.Email==_enrollment.Email && m.Password==_enrollment.Password).FirstOrDefault();
            if (result == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else {
                return RedirectToAction("Index", "Companies");
            }
            return View(_enrollment);
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
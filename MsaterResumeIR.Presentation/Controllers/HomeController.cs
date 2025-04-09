using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Presentation.Models;
using System.Diagnostics;

namespace MsaterResumeIR.Presentation.Controllers
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
            new test();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public record test(int Id)
    {
        public test() : this( 0) { }
        public int Id { get; init; }
    }



}

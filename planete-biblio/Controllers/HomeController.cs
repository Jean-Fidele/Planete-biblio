using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using planete_biblio.Data;
using planete_biblio.Models;
using System.Diagnostics;

namespace planete_biblio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext ctx;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx, Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment)
        {
            _logger = logger;
            this.ctx = ctx;
            this.Environment = Environment;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Service()
        {

            ViewData["data"] = Environment.WebRootPath;
            return View(ctx.Livre.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
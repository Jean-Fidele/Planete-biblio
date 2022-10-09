using Bibliotheque.Models;
using Data.Context;
using Facade.Contact;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bibliotheque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext ctx;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;
        protected readonly IMediator Mediator;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx, 
                                    IWebHostEnvironment Environment, IMediator mediator)
        {
            _logger = logger;
            this.ctx = ctx;
            this.Environment = Environment;
            Mediator = mediator;
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

        public async Task<IActionResult> Contact(GetContact.Request request)
        {
            return Ok(await Mediator.Send(new GetContact.Request { Id = 2, Username= "Mon nom"}));
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
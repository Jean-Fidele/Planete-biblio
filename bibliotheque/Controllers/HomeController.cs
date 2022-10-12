using Bibliotheque.Models;
using Data.Context;
using Domain.Entities;
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
        private readonly ApplicationDbContext _ctx;
        private readonly IWebHostEnvironment _Environment;
        private readonly IMediator _Mediator;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx, 
                                    IWebHostEnvironment Environment, IMediator mediator)
        {
            _logger = logger;
            _ctx = ctx;
            _Environment = Environment;
            _Mediator = mediator;
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

        [HttpGet("Contact")]
        public async Task<IActionResult> Contact(GetContact.Request request)
        {
            return Ok(await _Mediator.Send(new GetContact.Request { Id = 2, Username= "Mon nom"}));
        }

        public IActionResult Service()
        {
            ViewData["data"] = _Environment.WebRootPath;
            return View(_ctx.Set<Livre>().ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
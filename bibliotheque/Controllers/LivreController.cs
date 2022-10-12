using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Controllers
{
    public class LivreController : Controller
    {
        private readonly ApplicationDbContext ctx;
        

        public LivreController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(ctx.Set<Livre>().ToList());
        }

        public IActionResult Create()
        {
            return View(new Livre());
        }

        [HttpPost]
        public ActionResult Create(Livre livre)
        {
            if (!ModelState.IsValid)
            {
                return View(livre);
            }

            try
            {
                ctx.Set<Livre>().Add(livre);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livre);
            }
        }
    }
}

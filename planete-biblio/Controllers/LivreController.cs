using Microsoft.AspNetCore.Mvc;
using planete_biblio.Data;
using planete_biblio.Entities;

namespace planete_biblio.Controllers
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
            return View(ctx.Livre.ToList());
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
                ctx.Livre.Add(livre);
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

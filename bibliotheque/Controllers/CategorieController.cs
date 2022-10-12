using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace planete_biblio.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public CategorieController(ApplicationDbContext ctx) {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(ctx.Set<Categorie>().ToList());
        }

        public IActionResult Create()
        {
            return View(new Categorie());
        }

        [HttpPost]
        public ActionResult Create(Categorie categorie)
        {
            if (!ModelState.IsValid) {
                return View(categorie);
            }

            try
            {
                ctx.Set<Categorie>().Add(categorie);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categorie);
            }
        }
    }
}

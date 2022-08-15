using Microsoft.AspNetCore.Mvc;
using planete_biblio.Data;
using planete_biblio.Entities;

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
            return View(ctx.Categorie.ToList());
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
                ctx.Categorie.Add(categorie);
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

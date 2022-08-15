using Microsoft.AspNetCore.Mvc;
using planete_biblio.Data;

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
    }
}

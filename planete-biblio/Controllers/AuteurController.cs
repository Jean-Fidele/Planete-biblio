using Microsoft.AspNetCore.Mvc;

namespace planete_biblio.Controllers
{
    public class AuteurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

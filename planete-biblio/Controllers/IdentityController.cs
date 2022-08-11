using Microsoft.AspNetCore.Mvc;

namespace planete_biblio.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace planete_biblio.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(String username, String password)
        {
            if (!ModelState.IsValid) return View(username);

            var user = await _userManager.FindByEmailAsync(username);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, password);
                if (passwordCheck)
                {
                    //var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                    //if (result.Succeeded)
                    //{
                        var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
                        return RedirectToAction("About", "Home");
                    //}
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View("ErrorA");
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View("ErrorB");
        }

    }
}

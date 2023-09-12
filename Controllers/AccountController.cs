using AssessmentTransaction.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AssessmentTransaction.Controllers
{
    public class AccountController : Controller
    {
       
            private readonly ApplicationDbContext _dbContext;

            public AccountController(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(Users model)
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Sign in the user
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("AddOrEdit", "Transaction");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
        }

    }


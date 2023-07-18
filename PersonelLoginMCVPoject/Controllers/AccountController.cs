using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelLoginMCVPoject.Data;
using PersonelLoginMCVPoject.Migrations;
using PersonelLoginMCVPoject.Models;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace PersonelLoginMCVPoject.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var db = new PersonelListeleDbContext();

            var user = db.Users.Include(x => x.Roles).FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (user is not null)
            {
                List<Claim> claims = new List<Claim>();

                var userRole = db.Users.Where(x => x.Id == user.Id).SelectMany(x => x.Roles).ToList();

                var claims1 = new Claim(ClaimTypes.Name, user.UserName);
                var claims2 = new Claim(ClaimTypes.Email, user.Email);

                foreach (var item in userRole)
                {
                    var claims3 = new Claim(ClaimTypes.Role, item.Name);

                    claims.Add(claims3);

                }              
                claims.Add(claims1);
                claims.Add(claims2);
               

                var identity = new ClaimsIdentity(claims, "FB1907");
                var claimPrinciple = new ClaimsPrincipal(identity);
                var authProps = new AuthenticationProperties();

                authProps.IsPersistent = model.RememberMe; // cookie kalıcı olsun session bazl olmasın demek.

                if (model.RememberMe)
                {
                    authProps.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30);
                }
                HttpContext.SignInAsync(claimPrinciple, authProps);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [Authorize(AuthenticationSchemes = "FB1907")]
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("FB1907");
            return RedirectToAction("Index", "Home");
        }

    }
}

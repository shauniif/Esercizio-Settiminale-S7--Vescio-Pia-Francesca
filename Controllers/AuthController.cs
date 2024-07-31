using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRoleService _roleSvc;
        private readonly IAuthService _authSvc;

        public AuthController(IRoleService roleSvc, IAuthService authSvc)
        {
            _roleSvc = roleSvc;
            _authSvc = authSvc;
        }
        public async Task<IActionResult> AllRoles()
        {
            var roles = await _roleSvc.GetAll();
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(Role role)
        {
            if(ModelState.IsValid)
            {
                await _roleSvc.Create(role);
                return RedirectToAction("AllRoles", "Auth");
            } 
            return View(role);
        }

        public async Task<IActionResult> EditRole(int id) {
            var role = await _roleSvc.Read(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(Role role)
        {
            if (ModelState.IsValid)
            {
                await _roleSvc.Update(role);
                return RedirectToAction("AllRoles", "Auth");
            }
            return View(role);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleSvc.Read(id);
            return View(role);
        }
        
        public async Task<IActionResult> DeleteConfirmedRole(int id)
        {
            await _roleSvc.Delete(id);
            return RedirectToAction("AllRoles", "Auth");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel user)
        {   
            if(ModelState.IsValid)
            {
                await _authSvc.Create(user);
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            var u = await _authSvc.Login(user);
             if (u != null)
             {
                 var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, u.Name),
                     new Claim(ClaimTypes.Email, u.Email)
                     };
                 u.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                 var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                 await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(identity));
             } 
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
     
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EventsWeb.Helpers;
using EventsWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Controllers
{
    public class LoginController : Controller
    {

        private readonly eventsContext _context;

        public LoginController(eventsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Ideventtype"] = new SelectList(_context.Eventtype, "Ideventtype", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string username, string password)
        {
            LoginData loginData = new LoginData
            {
                Username = username,
                Password = password
            };
            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(t => t.Email == loginData.Username && t.Password == ShaHelper.ComputeSha256Hash(password));
                if (user == null)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return View();
                }
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, loginData.Username));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = loginData.RememberMe
                });
                return Redirect("/User/Index");
            }
            else
            {
                ModelState.AddModelError("", "username or password is blank");
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
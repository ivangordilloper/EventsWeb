using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EventsWeb.Helpers;
using EventsWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly eventsContext _context;

        public UserController(eventsContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.User.Include(u => u.IdusertypeNavigation);
            return View(await eventsContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.IdusertypeNavigation)
                .FirstOrDefaultAsync(m => m.Iduser == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["Idusertype"] = new SelectList(_context.Usertype, "Idusertype", "Description");
            ViewData["Idstate"] = new SelectList(_context.State, "Idstate", "Description");
            ViewData["Idgender"] = new SelectList(_context.Gender, "Idgender", "Description");

            return View();
        }
        [HttpPost]
        public JsonResult doesUserNameExist(string Email)
        {
            var user = _context.User.Where(t => t.Email.ToLower() == Email.ToLower()).FirstOrDefault();
            return Json(user == null);
        }
        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iduser,Name,Lastname,Surname,Idusertype,Email,Password")] User user, DateTime dob, int idgender, int idstate, string city, List<IFormFile> files)
        {
            user.Idusertype = 1;
            if (ModelState.IsValid)
            {
                SHA256 mySHA256 = SHA256.Create();
                user.Userinfo = new Userinfo
                {
                    Idgender = idgender,
                    Idstate = idstate,
                    City = city,
                    Dob = dob
                };
                user.Password = ShaHelper.ComputeSha256Hash(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                List<Documents> Documents = new List<Documents>();
                foreach (var item in files)
                {
                    Documents documents = new Documents();
                    using (var memoryStream = new MemoryStream())
                    {
                        item.CopyTo(memoryStream);
                        documents.Blob = memoryStream.ToArray();
                        documents.Description = item.FileName;
                    }
                    Documents.Add(documents);
                }
                var register = new Register
                {
                    Isvalid = false,
                    Iduser = user.Iduser,
                    Documents = Documents
                };
                _context.Add(register);
                await _context.SaveChangesAsync();
                return Redirect("/Register");
            }
            ViewData["Idusertype"] = new SelectList(_context.Usertype, "Idusertype", "Description", user.Idusertype);
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["Idusertype"] = new SelectList(_context.Usertype, "Idusertype", "Description", user.Idusertype);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iduser,Name,Lastname,Surname,Idusertype,Email,Password")] User user)
        {
            if (id != user.Iduser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Iduser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idusertype"] = new SelectList(_context.Usertype, "Idusertype", "Description", user.Idusertype);
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.IdusertypeNavigation)
                .FirstOrDefaultAsync(m => m.Iduser == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.Include(t => t.Userinfo).Include(t => t.Register).ThenInclude(d => d.Documents)
            .FirstOrDefaultAsync(t => t.Iduser == id);
            foreach (var item in user.Register)
            {
                _context.RemoveRange(item.Documents);
            }
            _context.Register.RemoveRange(user.Register);
            _context.Userinfo.Remove(user.Userinfo);
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Iduser == id);
        }
    }
}
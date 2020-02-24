using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsWeb.Models;

namespace EventsWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly eventsContext _context;

        public RegisterController(eventsContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Register.Include(r => r.IduserNavigation).Where(t => !t.Isvalid);
            return View(await eventsContext.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.IduserNavigation)
                .Include(d => d.Documents)
                .Include(i => i.IduserNavigation.Userinfo).ThenInclude(t => t.IdgenderNavigation)
                .Include(i => i.IduserNavigation.Userinfo).ThenInclude(t => t.IdstateNavigation)

                .FirstOrDefaultAsync(m => m.Idregister == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email");
            ViewData["Idusertype"] = new SelectList(_context.Usertype, "Idusertype", "Description");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idregister,Isvalid,Iduser")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", register.Iduser);
            return View(register);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", register.Iduser);
            return View(register);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idregister,Isvalid,Iduser")] Register register)
        {
            if (id != register.Idregister)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Idregister))
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
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", register.Iduser);
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Valid(int id, bool valid)
        {
            var register = await _context.Register.FindAsync(id);
            try
            {
                register.Isvalid = true;
                _context.Update(register);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(register.Idregister))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", register.Iduser);
            return RedirectToAction(nameof(Index));
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.IduserNavigation)
                .FirstOrDefaultAsync(m => m.Idregister == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }


        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Register.Include(t => t.Documents).Where(t => t.Idregister == id).FirstOrDefaultAsync();
            if (register?.Documents != null)
                _context.Documents.RemoveRange(register.Documents);
            _context.Register.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.Idregister == id);
        }

        [HttpGet]
        public FileResult GetFileResult(int documentId)
        {
            var document = _context.Documents.Find(documentId);
            return File(document.Blob, "application/octet-stream", document.Description);
        }
    }
}

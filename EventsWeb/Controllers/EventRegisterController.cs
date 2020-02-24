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
    public class EventRegisterController : Controller
    {
        private readonly eventsContext _context;

        public EventRegisterController(eventsContext context)
        {
            _context = context;
        }

        // GET: EventRegister
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Eventregister.Include(e => e.IdeventscheduleNavigation).Include(e => e.IduserNavigation);
            return View(await eventsContext.ToListAsync());
        }

        // GET: EventRegister/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventregister = await _context.Eventregister
                .Include(e => e.IdeventscheduleNavigation)
                .Include(e => e.IduserNavigation)
                .FirstOrDefaultAsync(m => m.Ideventregister == id);
            if (eventregister == null)
            {
                return NotFound();
            }

            return View(eventregister);
        }

        // GET: EventRegister/Create
        public IActionResult Create()
        {
            ViewData["Ideventschedule"] = new SelectList(_context.Eventschedule, "Ideventschedule", "Ideventschedule");
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email");
            return View();
        }

        // POST: EventRegister/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ideventregister,Ideventschedule,Iduser,Evaluation,Comments")] Eventregister eventregister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventregister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ideventschedule"] = new SelectList(_context.Eventschedule, "Ideventschedule", "Ideventschedule", eventregister.Ideventschedule);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventregister.Iduser);
            return View(eventregister);
        }

        // GET: EventRegister/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventregister = await _context.Eventregister.FindAsync(id);
            if (eventregister == null)
            {
                return NotFound();
            }
            ViewData["Ideventschedule"] = new SelectList(_context.Eventschedule, "Ideventschedule", "Ideventschedule", eventregister.Ideventschedule);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventregister.Iduser);
            return View(eventregister);
        }

        // POST: EventRegister/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Ideventregister,Ideventschedule,Iduser,Evaluation,Comments")] Eventregister eventregister)
        {
            if (id != eventregister.Ideventregister)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventregister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventregisterExists(eventregister.Ideventregister))
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
            ViewData["Ideventschedule"] = new SelectList(_context.Eventschedule, "Ideventschedule", "Ideventschedule", eventregister.Ideventschedule);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventregister.Iduser);
            return View(eventregister);
        }

        // GET: EventRegister/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventregister = await _context.Eventregister
                .Include(e => e.IdeventscheduleNavigation)
                .Include(e => e.IduserNavigation)
                .FirstOrDefaultAsync(m => m.Ideventregister == id);
            if (eventregister == null)
            {
                return NotFound();
            }

            return View(eventregister);
        }

        // POST: EventRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var eventregister = await _context.Eventregister.FindAsync(id);
            _context.Eventregister.Remove(eventregister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventregisterExists(long id)
        {
            return _context.Eventregister.Any(e => e.Ideventregister == id);
        }
    }
}

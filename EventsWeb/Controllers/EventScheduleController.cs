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
    public class EventScheduleController : Controller
    {
        private readonly eventsContext _context;

        public EventScheduleController(eventsContext context)
        {
            _context = context;
        }

        // GET: EventSchedule
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Eventschedule.Include(e => e.IdeventNavigation).Include(e => e.IduserNavigation);
            return View(await eventsContext.ToListAsync());
        }

        // GET: EventSchedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventschedule = await _context.Eventschedule
                .Include(e => e.IdeventNavigation)
                .Include(e => e.IduserNavigation)
                .FirstOrDefaultAsync(m => m.Ideventschedule == id);
            if (eventschedule == null)
            {
                return NotFound();
            }

            return View(eventschedule);
        }

        // GET: EventSchedule/Create
        public IActionResult Create()
        {
            ViewData["Idevent"] = new SelectList(_context.Event, "Idevent", "Description");
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email");
            return View();
        }

        // POST: EventSchedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ideventschedule,Idevent,Iduser,Datestart,Dateend")] Eventschedule eventschedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventschedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idevent"] = new SelectList(_context.Event, "Idevent", "Description", eventschedule.Idevent);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventschedule.Iduser);
            return View(eventschedule);
        }

        // GET: EventSchedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventschedule = await _context.Eventschedule.FindAsync(id);
            if (eventschedule == null)
            {
                return NotFound();
            }
            ViewData["Idevent"] = new SelectList(_context.Event, "Idevent", "Description", eventschedule.Idevent);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventschedule.Iduser);
            return View(eventschedule);
        }

        // POST: EventSchedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ideventschedule,Idevent,Iduser,Datestart,Dateend")] Eventschedule eventschedule)
        {
            if (id != eventschedule.Ideventschedule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventschedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventscheduleExists(eventschedule.Ideventschedule))
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
            ViewData["Idevent"] = new SelectList(_context.Event, "Idevent", "Description", eventschedule.Idevent);
            ViewData["Iduser"] = new SelectList(_context.User, "Iduser", "Email", eventschedule.Iduser);
            return View(eventschedule);
        }

        // GET: EventSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventschedule = await _context.Eventschedule
                .Include(e => e.IdeventNavigation)
                .Include(e => e.IduserNavigation)
                .FirstOrDefaultAsync(m => m.Ideventschedule == id);
            if (eventschedule == null)
            {
                return NotFound();
            }

            return View(eventschedule);
        }

        // POST: EventSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventschedule = await _context.Eventschedule.FindAsync(id);
            _context.Eventschedule.Remove(eventschedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventscheduleExists(int id)
        {
            return _context.Eventschedule.Any(e => e.Ideventschedule == id);
        }
    }
}

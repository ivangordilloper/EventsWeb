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
    public class EventTypeController : Controller
    {
        private readonly eventsContext _context;

        public EventTypeController(eventsContext context)
        {
            _context = context;
        }

        // GET: EventType
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eventtype.ToListAsync());
        }

        // GET: EventType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.Eventtype
                .FirstOrDefaultAsync(m => m.Ideventtype == id);
            if (eventtype == null)
            {
                return NotFound();
            }

            return View(eventtype);
        }

        // GET: EventType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ideventtype,Description")] Eventtype eventtype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventtype);
        }

        // GET: EventType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.Eventtype.FindAsync(id);
            if (eventtype == null)
            {
                return NotFound();
            }
            return View(eventtype);
        }

        // POST: EventType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ideventtype,Description")] Eventtype eventtype)
        {
            if (id != eventtype.Ideventtype)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventtype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventtypeExists(eventtype.Ideventtype))
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
            return View(eventtype);
        }

        // GET: EventType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.Eventtype
                .FirstOrDefaultAsync(m => m.Ideventtype == id);
            if (eventtype == null)
            {
                return NotFound();
            }

            return View(eventtype);
        }

        // POST: EventType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventtype = await _context.Eventtype.FindAsync(id);
            _context.Eventtype.Remove(eventtype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventtypeExists(int id)
        {
            return _context.Eventtype.Any(e => e.Ideventtype == id);
        }
    }
}

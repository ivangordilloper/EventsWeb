using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Controllers {
    public class DocumentController : Controller {
        private readonly eventsContext _context;

        public DocumentController (eventsContext context) {
            _context = context;
        }

        // GET: Document
        public async Task<IActionResult> Index () {
            var eventsContext = _context.Documents.Include (d => d.IdregisterNavigation);
            return View (await eventsContext.ToListAsync ());
        }

        // GET: Document/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var documents = await _context.Documents
                .Include (d => d.IdregisterNavigation)
                .FirstOrDefaultAsync (m => m.Iddocument == id);
            if (documents == null) {
                return NotFound ();
            }

            return View (documents);
        }

        // GET: Document/Create
        public IActionResult Create () {
            ViewData["Idregister"] = new SelectList (_context.Register, "Idregister", "Idregister");
            return View ();
        }

        // POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Iddocument,Description,Blob,Idregister")] Documents documents) {
            if (ModelState.IsValid) {
                _context.Add (documents);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["Idregister"] = new SelectList (_context.Register, "Idregister", "Idregister", documents.Idregister);
            return View (documents);
        }

        // GET: Document/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var documents = await _context.Documents.FindAsync (id);
            if (documents == null) {
                return NotFound ();
            }
            ViewData["Idregister"] = new SelectList (_context.Register, "Idregister", "Idregister", documents.Idregister);
            return View (documents);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Iddocument,Description,Blob,Idregister")] Documents documents) {
            if (id != documents.Iddocument) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (documents);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!DocumentsExists (documents.Iddocument)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            ViewData["Idregister"] = new SelectList (_context.Register, "Idregister", "Idregister", documents.Idregister);
            return View (documents);
        }

        // GET: Document/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var documents = await _context.Documents
                .Include (d => d.IdregisterNavigation)
                .FirstOrDefaultAsync (m => m.Iddocument == id);
            if (documents == null) {
                return NotFound ();
            }

            return View (documents);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var documents = await _context.Documents.FindAsync (id);
            _context.Documents.Remove (documents);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool DocumentsExists (int id) {
            return _context.Documents.Any (e => e.Iddocument == id);
        }
    }
}
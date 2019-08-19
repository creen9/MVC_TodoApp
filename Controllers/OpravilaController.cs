using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class OpravilaController : Controller
    {
        private readonly OpravilaContext _context;

        public OpravilaController(OpravilaContext context)
        {
            _context = context;
        }

        // GET: Opravila
        public async Task<IActionResult> Index()
        {
            return View(await _context.Opravilo.ToListAsync());
        }

        // GET: Opravila/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opravilo = await _context.Opravilo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opravilo == null)
            {
                return NotFound();
            }

            return View(opravilo);
        }

        // GET: Opravila/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opravila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Oseba,Opis,DatumZakljucka")] Opravilo opravilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opravilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opravilo);
        }

        // GET: Opravila/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opravilo = await _context.Opravilo.FindAsync(id);
            if (opravilo == null)
            {
                return NotFound();
            }
            return View(opravilo);
        }

        // POST: Opravila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Oseba,Opis,DatumZakljucka")] Opravilo opravilo)
        {
            if (id != opravilo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opravilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpraviloExists(opravilo.Id))
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
            return View(opravilo);
        }

        // GET: Opravila/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opravilo = await _context.Opravilo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opravilo == null)
            {
                return NotFound();
            }

            return View(opravilo);
        }

        // POST: Opravila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opravilo = await _context.Opravilo.FindAsync(id);
            _context.Opravilo.Remove(opravilo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpraviloExists(int id)
        {
            return _context.Opravilo.Any(e => e.Id == id);
        }
    }
}

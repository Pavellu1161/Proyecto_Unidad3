using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Triaje.Data;
using Triaje.Models;

namespace Triaje.Controllers
{
    public class TriajeNsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TriajeNsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TriajeNs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TriajeNs.ToListAsync());
        }

        // GET: TriajeNs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triajeN = await _context.TriajeNs
                .FirstOrDefaultAsync(m => m.IdConsultaN == id);
            if (triajeN == null)
            {
                return NotFound();
            }

            return View(triajeN);
        }

        // GET: TriajeNs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TriajeNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsultaN,Tuberculosis,Gripe")] TriajeN triajeN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(triajeN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(triajeN);
        }

        // GET: TriajeNs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triajeN = await _context.TriajeNs.FindAsync(id);
            if (triajeN == null)
            {
                return NotFound();
            }
            return View(triajeN);
        }

        // POST: TriajeNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsultaN,Tuberculosis,Gripe")] TriajeN triajeN)
        {
            if (id != triajeN.IdConsultaN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(triajeN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriajeNExists(triajeN.IdConsultaN))
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
            return View(triajeN);
        }

        // GET: TriajeNs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triajeN = await _context.TriajeNs
                .FirstOrDefaultAsync(m => m.IdConsultaN == id);
            if (triajeN == null)
            {
                return NotFound();
            }

            return View(triajeN);
        }

        // POST: TriajeNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var triajeN = await _context.TriajeNs.FindAsync(id);
            _context.TriajeNs.Remove(triajeN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriajeNExists(int id)
        {
            return _context.TriajeNs.Any(e => e.IdConsultaN == id);
        }
    }
}

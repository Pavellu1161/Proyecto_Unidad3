using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Triaje.Data;
using Triaje.Models.TriajeGeneral;

namespace Triaje.Controllers
{
    public class TipoPrioridadesGeneralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPrioridadesGeneralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPrioridadesGeneral
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposPrioridades.ToListAsync());
        }

        // GET: TipoPrioridadesGeneral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrioridad = await _context.TiposPrioridades
                .FirstOrDefaultAsync(m => m.IdPrioridadGeneral == id);
            if (tipoPrioridad == null)
            {
                return NotFound();
            }

            return View(tipoPrioridad);
        }

        // GET: TipoPrioridadesGeneral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPrioridadesGeneral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrioridadGeneral,Nombre")] TipoPrioridad tipoPrioridad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPrioridad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPrioridad);
        }

        // GET: TipoPrioridadesGeneral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrioridad = await _context.TiposPrioridades.FindAsync(id);
            if (tipoPrioridad == null)
            {
                return NotFound();
            }
            return View(tipoPrioridad);
        }

        // POST: TipoPrioridadesGeneral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrioridadGeneral,Nombre")] TipoPrioridad tipoPrioridad)
        {
            if (id != tipoPrioridad.IdPrioridadGeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPrioridad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPrioridadExists(tipoPrioridad.IdPrioridadGeneral))
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
            return View(tipoPrioridad);
        }

        // GET: TipoPrioridadesGeneral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPrioridad = await _context.TiposPrioridades
                .FirstOrDefaultAsync(m => m.IdPrioridadGeneral == id);
            if (tipoPrioridad == null)
            {
                return NotFound();
            }

            return View(tipoPrioridad);
        }

        // POST: TipoPrioridadesGeneral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPrioridad = await _context.TiposPrioridades.FindAsync(id);
            _context.TiposPrioridades.Remove(tipoPrioridad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPrioridadExists(int id)
        {
            return _context.TiposPrioridades.Any(e => e.IdPrioridadGeneral == id);
        }
    }
}

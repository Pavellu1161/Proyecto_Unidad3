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
    public class SignosGeneralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignosGeneralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SignosGeneral
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Signos.Include(s => s.TipoPrioridades).Include(s => s.TipoSignos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SignosGeneral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signo = await _context.Signos
                .Include(s => s.TipoPrioridades)
                .Include(s => s.TipoSignos)
                .FirstOrDefaultAsync(m => m.IdSignoGeneral == id);
            if (signo == null)
            {
                return NotFound();
            }

            return View(signo);
        }

        // GET: SignosGeneral/Create
        public IActionResult Create()
        {
            ViewData["IdPrioridadGeneral"] = new SelectList(_context.TiposPrioridades, "IdPrioridadGeneral", "Nombre");
            ViewData["IdTipoSignoGeneral"] = new SelectList(_context.TipoSignos, "IdTipoSignoGeneral", "Nombre");
            return View();
        }

        // POST: SignosGeneral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSignoGeneral,Nombre,IdPrioridadGeneral,IdTipoSignoGeneral")] Signo signo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrioridadGeneral"] = new SelectList(_context.TiposPrioridades, "IdPrioridadGeneral", "IdPrioridadGeneral", signo.IdPrioridadGeneral);
            ViewData["IdTipoSignoGeneral"] = new SelectList(_context.TipoSignos, "IdTipoSignoGeneral", "IdTipoSignoGeneral", signo.IdTipoSignoGeneral);
            return View(signo);
        }

        // GET: SignosGeneral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signo = await _context.Signos.FindAsync(id);
            if (signo == null)
            {
                return NotFound();
            }
            ViewData["IdPrioridadGeneral"] = new SelectList(_context.TiposPrioridades, "IdPrioridadGeneral", "Nombre", signo.IdPrioridadGeneral);
            ViewData["IdTipoSignoGeneral"] = new SelectList(_context.TipoSignos, "IdTipoSignoGeneral", "Nombre", signo.IdTipoSignoGeneral);
            return View(signo);
        }

        // POST: SignosGeneral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSignoGeneral,Nombre,IdPrioridadGeneral,IdTipoSignoGeneral")] Signo signo)
        {
            if (id != signo.IdSignoGeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignoExists(signo.IdSignoGeneral))
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
            ViewData["IdPrioridadGeneral"] = new SelectList(_context.TiposPrioridades, "IdPrioridadGeneral", "IdPrioridadGeneral", signo.IdPrioridadGeneral);
            ViewData["IdTipoSignoGeneral"] = new SelectList(_context.TipoSignos, "IdTipoSignoGeneral", "IdTipoSignoGeneral", signo.IdTipoSignoGeneral);
            return View(signo);
        }

        // GET: SignosGeneral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signo = await _context.Signos
                .Include(s => s.TipoPrioridades)
                .Include(s => s.TipoSignos)
                .FirstOrDefaultAsync(m => m.IdSignoGeneral == id);
            if (signo == null)
            {
                return NotFound();
            }

            return View(signo);
        }

        // POST: SignosGeneral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signo = await _context.Signos.FindAsync(id);
            _context.Signos.Remove(signo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignoExists(int id)
        {
            return _context.Signos.Any(e => e.IdSignoGeneral == id);
        }
    }
}

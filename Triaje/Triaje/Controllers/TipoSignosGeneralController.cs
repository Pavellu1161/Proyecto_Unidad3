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
    public class TipoSignosGeneralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoSignosGeneralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoSignosGeneral
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSignos.ToListAsync());
        }

        // GET: TipoSignosGeneral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSigno = await _context.TipoSignos
                .FirstOrDefaultAsync(m => m.IdTipoSignoGeneral == id);
            if (tipoSigno == null)
            {
                return NotFound();
            }

            return View(tipoSigno);
        }

        // GET: TipoSignosGeneral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSignosGeneral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSignoGeneral,Nombre")] TipoSigno tipoSigno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSigno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSigno);
        }

        // GET: TipoSignosGeneral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSigno = await _context.TipoSignos.FindAsync(id);
            if (tipoSigno == null)
            {
                return NotFound();
            }
            return View(tipoSigno);
        }

        // POST: TipoSignosGeneral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoSignoGeneral,Nombre")] TipoSigno tipoSigno)
        {
            if (id != tipoSigno.IdTipoSignoGeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSigno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSignoExists(tipoSigno.IdTipoSignoGeneral))
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
            return View(tipoSigno);
        }

        // GET: TipoSignosGeneral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSigno = await _context.TipoSignos
                .FirstOrDefaultAsync(m => m.IdTipoSignoGeneral == id);
            if (tipoSigno == null)
            {
                return NotFound();
            }

            return View(tipoSigno);
        }

        // POST: TipoSignosGeneral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSigno = await _context.TipoSignos.FindAsync(id);
            _context.TipoSignos.Remove(tipoSigno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSignoExists(int id)
        {
            return _context.TipoSignos.Any(e => e.IdTipoSignoGeneral == id);
        }
    }
}

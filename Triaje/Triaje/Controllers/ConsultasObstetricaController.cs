using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triaje.Data;
using Triaje.Models;

namespace Triaje.Controllers
{
    public class ConsultasObstetricaController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ConsultasObstetricaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsultasObstetrica
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Obstetricas.Include(c => c.Paciente).Include(c => c.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsultasObstetricas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaObstetrica = await _context.Obstetricas
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaObstetrica == null)
            {
                return NotFound();
            }

            return View(consultaObstetrica);
        }

        // GET: ConsultasObstetrica/Create
        public IActionResult Create()
        {
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente");
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal");
            return View();
        }

        // POST: ConsultasObstetrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,Paro_Cardiorespiratorio,Crisis_Convulsiva,Dolor_CSD,Movimientos_Fetales,sistolica,diastolica,saturacion,Frecuencia_Cardiaca,Temperatura_Axilar,Frecuencia_Respiratoria,IdentidadPaciente,IdentidadPersonal,Comentario")] ConsultaObstetrica consultaObstetrica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaObstetrica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaObstetrica.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaObstetrica.IdentidadPersonal);
            return View(consultaObstetrica);
        }

        // GET: ConsultasObstetrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaObstetrica = await _context.Obstetricas.FindAsync(id);
            if (consultaObstetrica == null)
            {
                return NotFound();
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaObstetrica.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaObstetrica.IdentidadPersonal);
            return View(consultaObstetrica);
        }

        // POST: ConsultasObstetrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,Paro_Cardiorespiratorio,Crisis_Convulsiva,Dolor_CSD,Movimientos_Fetales,sistolica,diastolica,saturacion,Frecuencia_Cardiaca,Temperatura_Axilar,Frecuencia_Respiratoria,IdentidadPaciente,IdentidadPersonal,Comentario")] ConsultaObstetrica consultaObstetrica)
        {
            if (id != consultaObstetrica.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaObstetrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaObstetricaExists(consultaObstetrica.IdConsulta))
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
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaObstetrica.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaObstetrica.IdentidadPersonal);
            return View(consultaObstetrica);
        }

        // GET: ConsultasObstetrica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaObstetrica = await _context.Obstetricas
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaObstetrica == null)
            {
                return NotFound();
            }

            return View(consultaObstetrica);
        }

        // POST: ConsultasObstetrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaObstetrica = await _context.Obstetricas.FindAsync(id);
            _context.Obstetricas.Remove(consultaObstetrica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaObstetricaExists(int id)
        {
            return _context.Obstetricas.Any(e => e.IdConsulta == id);
        }

    }
}

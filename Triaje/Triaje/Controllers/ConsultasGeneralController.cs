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
    public class ConsultasGeneralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasGeneralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsultasGeneral
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultas.Include(c => c.Paciente).Include(c => c.Personal).Include(c => c.Signo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsultasGeneral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .Include(c => c.Signo)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: ConsultasGeneral/Create
        public IActionResult Create()
        {
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente");
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "NombresPersonal");
            ViewData["IdSignoGeneral"] = new SelectList(_context.Signos, "IdSignoGeneral", "Nombre");
            return View();
        }

        // POST: ConsultasGeneral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,Fecha_Hora,MotivoConsulta,IdSignoGeneral,HoraTriaje,IdentidadPaciente,IdentidadPersonal")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consulta.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consulta.IdentidadPersonal);
            ViewData["IdSignoGeneral"] = new SelectList(_context.Signos, "IdSignoGeneral", "IdSignoGeneral", consulta.IdSignoGeneral);
            return View(consulta);
        }

        // GET: ConsultasGeneral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consulta.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "NombresPersonal", consulta.IdentidadPersonal);
            ViewData["IdSignoGeneral"] = new SelectList(_context.Signos, "IdSignoGeneral", "Nombre", consulta.IdSignoGeneral);
            return View(consulta);
        }

        // POST: ConsultasGeneral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,Fecha_Hora,MotivoConsulta,IdSignoGeneral,HoraTriaje,IdentidadPaciente,IdentidadPersonal")] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.IdConsulta))
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
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consulta.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consulta.IdentidadPersonal);
            ViewData["IdSignoGeneral"] = new SelectList(_context.Signos, "IdSignoGeneral", "IdSignoGeneral", consulta.IdSignoGeneral);
            return View(consulta);
        }

        // GET: ConsultasGeneral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .Include(c => c.Signo)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: ConsultasGeneral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.IdConsulta == id);
        }
    }
}

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
    public class ConsultasPediatriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasPediatriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsultasPediatria
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pediatrias.Include(c => c.Paciente).Include(c => c.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsultasPediatria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPediatria = await _context.Pediatrias
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaPediatria == null)
            {
                return NotFound();
            }

            return View(consultaPediatria);
        }

        // GET: ConsultasPediatria/Create
        public IActionResult Create()
        {
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente");
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal");
            return View();
        }

        // POST: ConsultasPediatria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,Hemorragia_Incontrolable,Herida_Arma,Gran_Quemado,Dengue_Grave,Mordeduras_Graves,Paciente_Oncologico,Estridor_Laringeo,Trauma_Ocular,Varicela_Sobreinfectada,Ingesta_Cuerpos_Extraños,Cafalea_Aguda,Urticaria,Otalgia,Dolor_Toracico,Contusiones_Menores,Patologia_Respiratoria,Dolor_Garganta,Estrenimiento_Cronico,Dolor_Abdominal,Curaciones,IdentidadPaciente,IdentidadPersonal,Comentario")] ConsultaPediatria consultaPediatria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaPediatria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaPediatria.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaPediatria.IdentidadPersonal);
            return View(consultaPediatria);
        }

        // GET: ConsultasPediatria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPediatria = await _context.Pediatrias.FindAsync(id);
            if (consultaPediatria == null)
            {
                return NotFound();
            }
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaPediatria.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaPediatria.IdentidadPersonal);
            return View(consultaPediatria);
        }

        // POST: ConsultasPediatria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,Hemorragia_Incontrolable,Herida_Arma,Gran_Quemado,Dengue_Grave,Mordeduras_Graves,Paciente_Oncologico,Estridor_Laringeo,Trauma_Ocular,Varicela_Sobreinfectada,Ingesta_Cuerpos_Extraños,Cafalea_Aguda,Urticaria,Otalgia,Dolor_Toracico,Contusiones_Menores,Patologia_Respiratoria,Dolor_Garganta,Estrenimiento_Cronico,Dolor_Abdominal,Curaciones,IdentidadPaciente,IdentidadPersonal,Comentario")] ConsultaPediatria consultaPediatria)
        {
            if (id != consultaPediatria.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaPediatria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaPediatriaExists(consultaPediatria.IdConsulta))
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
            ViewData["IdentidadPaciente"] = new SelectList(_context.Pacientes, "IdentidadPaciente", "IdentidadPaciente", consultaPediatria.IdentidadPaciente);
            ViewData["IdentidadPersonal"] = new SelectList(_context.Personals, "IdentidadPersonal", "IdentidadPersonal", consultaPediatria.IdentidadPersonal);
            return View(consultaPediatria);
        }

        // GET: ConsultasPediatria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaPediatria = await _context.Pediatrias
                .Include(c => c.Paciente)
                .Include(c => c.Personal)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultaPediatria == null)
            {
                return NotFound();
            }

            return View(consultaPediatria);
        }

        // POST: ConsultasPediatria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaPediatria = await _context.Pediatrias.FindAsync(id);
            _context.Pediatrias.Remove(consultaPediatria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaPediatriaExists(int id)
        {
            return _context.Pediatrias.Any(e => e.IdConsulta == id);
        }
    }
}

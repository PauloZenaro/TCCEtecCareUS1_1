using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareUS1_1.Data;
using CareUS1_1.Models;

namespace CareUS1_1.Controllers
{
    public class PacientesMVCController : Controller
    {
        private readonly CareUS1_1Context _context;

        public PacientesMVCController(CareUS1_1Context context)
        {
            _context = context;
        }

        // GET: PacientesMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Paciente.ToListAsync());
        }

        // GET: PacientesMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.GuidPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: PacientesMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacientesMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidPaciente,fkGuidCliente,nomePaciente,dataDeNascimentoPaciente")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.GuidPaciente = Guid.NewGuid();
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: PacientesMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: PacientesMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidPaciente,fkGuidCliente,nomePaciente,dataDeNascimentoPaciente")] Paciente paciente)
        {
            if (id != paciente.GuidPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.GuidPaciente))
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
            return View(paciente);
        }

        // GET: PacientesMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.GuidPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: PacientesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Paciente == null)
            {
                return Problem("Entity set 'CareUS1_1Context.Paciente'  is null.");
            }
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente != null)
            {
                _context.Paciente.Remove(paciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
          return _context.Paciente.Any(e => e.GuidPaciente == id);
        }
    }
}

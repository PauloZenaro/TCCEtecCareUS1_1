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
    public class ExperienciasMVCController : Controller
    {
        private readonly CareUS1_1Context _context;

        public ExperienciasMVCController(CareUS1_1Context context)
        {
            _context = context;
        }

        // GET: ExperienciasMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Experiencia.ToListAsync());
        }

        // GET: ExperienciasMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia
                .FirstOrDefaultAsync(m => m.GuidExperiencia == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // GET: ExperienciasMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienciasMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidExperiencia,fkGuidCliente,descricaoExperiencia")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                experiencia.GuidExperiencia = Guid.NewGuid();
                _context.Add(experiencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencia);
        }

        // GET: ExperienciasMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }
            return View(experiencia);
        }

        // POST: ExperienciasMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidExperiencia,fkGuidCliente,descricaoExperiencia")] Experiencia experiencia)
        {
            if (id != experiencia.GuidExperiencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaExists(experiencia.GuidExperiencia))
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
            return View(experiencia);
        }

        // GET: ExperienciasMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia
                .FirstOrDefaultAsync(m => m.GuidExperiencia == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // POST: ExperienciasMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Experiencia == null)
            {
                return Problem("Entity set 'CareUS1_1Context.Experiencia'  is null.");
            }
            var experiencia = await _context.Experiencia.FindAsync(id);
            if (experiencia != null)
            {
                _context.Experiencia.Remove(experiencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaExists(Guid id)
        {
          return _context.Experiencia.Any(e => e.GuidExperiencia == id);
        }
    }
}

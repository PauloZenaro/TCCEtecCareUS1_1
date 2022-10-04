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
    public class ContatosMVCController : Controller
    {
        private readonly CareUS1_1Context _context;

        public ContatosMVCController(CareUS1_1Context context)
        {
            _context = context;
        }

        // GET: ContatosMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contato.ToListAsync());
        }

        // GET: ContatosMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.GuidContato == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: ContatosMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContatosMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidContato,fkIdCliente,telefone,nomeContato")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                contato.GuidContato = Guid.NewGuid();
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: ContatosMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: ContatosMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidContato,fkIdCliente,telefone,nomeContato")] Contato contato)
        {
            if (id != contato.GuidContato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.GuidContato))
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
            return View(contato);
        }

        // GET: ContatosMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.GuidContato == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: ContatosMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Contato == null)
            {
                return Problem("Entity set 'CareUS1_1Context.Contato'  is null.");
            }
            var contato = await _context.Contato.FindAsync(id);
            if (contato != null)
            {
                _context.Contato.Remove(contato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(Guid id)
        {
          return _context.Contato.Any(e => e.GuidContato == id);
        }
    }
}

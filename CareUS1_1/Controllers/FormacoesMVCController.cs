using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareUS1_1.Data;
using CareUS1_1.Models.CareUs.Models;

namespace CareUS1_1.Controllers
{
    public class FormacoesMVCController : Controller
    {
        private readonly CareUS1_1Context _context;

        public FormacoesMVCController(CareUS1_1Context context)
        {
            _context = context;
        }

        // GET: FormacoesMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Formacao.ToListAsync());
        }

        // GET: FormacoesMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Formacao == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.GuidFormacao == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: FormacoesMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormacoesMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidFormacao,fkGuidCliente,descricaoFormacao")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                formacao.GuidFormacao = Guid.NewGuid();
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formacao);
        }

        // GET: FormacoesMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Formacao == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao.FindAsync(id);
            if (formacao == null)
            {
                return NotFound();
            }
            return View(formacao);
        }

        // POST: FormacoesMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidFormacao,fkGuidCliente,descricaoFormacao")] Formacao formacao)
        {
            if (id != formacao.GuidFormacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoExists(formacao.GuidFormacao))
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
            return View(formacao);
        }

        // GET: FormacoesMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Formacao == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.GuidFormacao == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: FormacoesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Formacao == null)
            {
                return Problem("Entity set 'CareUS1_1Context.Formacao'  is null.");
            }
            var formacao = await _context.Formacao.FindAsync(id);
            if (formacao != null)
            {
                _context.Formacao.Remove(formacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(Guid id)
        {
          return _context.Formacao.Any(e => e.GuidFormacao == id);
        }
    }
}

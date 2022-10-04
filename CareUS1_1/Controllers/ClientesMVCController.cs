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
    public class ClientesMVCController : Controller
    {
        private readonly CareUS1_1Context _context;

        public ClientesMVCController(CareUS1_1Context context)
        {
            _context = context;
        }

        // GET: ClientesMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cliente.ToListAsync());
        }

        // GET: ClientesMVC/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.GuidCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: ClientesMVC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuidCliente,nome,dataNascimentoCliente,cpf,rg,email,senha")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.GuidCliente = Guid.NewGuid();
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClientesMVC/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClientesMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuidCliente,nome,dataNascimentoCliente,cpf,rg,email,senha")] Cliente cliente)
        {
            if (id != cliente.GuidCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.GuidCliente))
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
            return View(cliente);
        }

        // GET: ClientesMVC/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.GuidCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClientesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'CareUS1_1Context.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(Guid id)
        {
          return _context.Cliente.Any(e => e.GuidCliente == id);
        }
    }
}

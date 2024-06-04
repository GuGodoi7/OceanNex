using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OceanNex.Models;
using OceanNex.Persistencia;

namespace OceanNex.Properties
{
    public class BiologoesController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public BiologoesController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Biologoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biologo.ToListAsync());
        }

        // GET: Biologoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = await _context.Biologo
                .FirstOrDefaultAsync(m => m.ContaId == id);
            if (biologo == null)
            {
                return NotFound();
            }

            return View(biologo);
        }

        // GET: Biologoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biologoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiologoId,NumeroRegistro,CPF,CRBio,ContaId,NomeConta,Email,Senha")] Biologo biologo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biologo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biologo);
        }

        // GET: Biologoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo == null)
            {
                return NotFound();
            }
            return View(biologo);
        }

        // POST: Biologoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiologoId,NumeroRegistro,CPF,CRBio,ContaId,NomeConta,Email,Senha")] Biologo biologo)
        {
            if (id != biologo.ContaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biologo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologoExists(biologo.ContaId))
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
            return View(biologo);
        }

        // GET: Biologoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = await _context.Biologo
                .FirstOrDefaultAsync(m => m.ContaId == id);
            if (biologo == null)
            {
                return NotFound();
            }

            return View(biologo);
        }

        // POST: Biologoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biologo = await _context.Biologo.FindAsync(id);
            if (biologo != null)
            {
                _context.Biologo.Remove(biologo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiologoExists(int id)
        {
            return _context.Biologo.Any(e => e.ContaId == id);
        }
    }
}

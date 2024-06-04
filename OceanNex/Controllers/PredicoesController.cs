using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OceanNex.Models;
using OceanNex.Persistencia;

namespace OceanNex.Controllers
{
    public class PredicoesController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public PredicoesController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Predicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Predicao.ToListAsync());
        }

        // GET: Predicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predicao = await _context.Predicao
                .FirstOrDefaultAsync(m => m.PredicaoId == id);
            if (predicao == null)
            {
                return NotFound();
            }

            return View(predicao);
        }

        // GET: Predicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PredicaoId,TaxaPredicao,DescricaoPredicao")] Predicao predicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predicao);
        }

        // GET: Predicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predicao = await _context.Predicao.FindAsync(id);
            if (predicao == null)
            {
                return NotFound();
            }
            return View(predicao);
        }

        // POST: Predicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PredicaoId,TaxaPredicao,DescricaoPredicao")] Predicao predicao)
        {
            if (id != predicao.PredicaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredicaoExists(predicao.PredicaoId))
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
            return View(predicao);
        }

        // GET: Predicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predicao = await _context.Predicao
                .FirstOrDefaultAsync(m => m.PredicaoId == id);
            if (predicao == null)
            {
                return NotFound();
            }

            return View(predicao);
        }

        // POST: Predicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predicao = await _context.Predicao.FindAsync(id);
            if (predicao != null)
            {
                _context.Predicao.Remove(predicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredicaoExists(int id)
        {
            return _context.Predicao.Any(e => e.PredicaoId == id);
        }
    }
}

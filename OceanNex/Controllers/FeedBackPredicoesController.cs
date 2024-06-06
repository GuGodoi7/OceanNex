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
    public class FeedBackPredicoesController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public FeedBackPredicoesController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: FeedBackPredicoes
        public async Task<IActionResult> Index()
        {
            var oracleFIAPDbContext = _context.FeedBackPredicao.Include(f => f.Conta).Include(f => f.Predicao);
            return View(await oracleFIAPDbContext.ToListAsync());
        }

        // GET: FeedBackPredicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = await _context.FeedBackPredicao
                .Include(f => f.Conta)
                .Include(f => f.Predicao)
                .FirstOrDefaultAsync(m => m.FeedBackPredicaoId == id);
            if (feedBackPredicao == null)
            {
                return NotFound();
            }

            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email");
            ViewData["PredicaoId"] = new SelectList(_context.Predicao, "PredicaoId", "DescricaoPredicao");
            return View();
        }

        // POST: FeedBackPredicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedBackPredicaoId,StatusFeedBackPredicao,DescricaoFeedBackPredicao,PredicaoId,ContaId")] FeedBackPredicao feedBackPredicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedBackPredicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPredicao.ContaId);
            ViewData["PredicaoId"] = new SelectList(_context.Predicao, "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = await _context.FeedBackPredicao.FindAsync(id);
            if (feedBackPredicao == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPredicao.ContaId);
            ViewData["PredicaoId"] = new SelectList(_context.Predicao, "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // POST: FeedBackPredicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedBackPredicaoId,StatusFeedBackPredicao,DescricaoFeedBackPredicao,PredicaoId,ContaId")] FeedBackPredicao feedBackPredicao)
        {
            if (id != feedBackPredicao.FeedBackPredicaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedBackPredicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackPredicaoExists(feedBackPredicao.FeedBackPredicaoId))
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
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPredicao.ContaId);
            ViewData["PredicaoId"] = new SelectList(_context.Predicao, "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = await _context.FeedBackPredicao
                .Include(f => f.Conta)
                .Include(f => f.Predicao)
                .FirstOrDefaultAsync(m => m.FeedBackPredicaoId == id);
            if (feedBackPredicao == null)
            {
                return NotFound();
            }

            return View(feedBackPredicao);
        }

        // POST: FeedBackPredicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedBackPredicao = await _context.FeedBackPredicao.FindAsync(id);
            if (feedBackPredicao != null)
            {
                _context.FeedBackPredicao.Remove(feedBackPredicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackPredicaoExists(int id)
        {
            return _context.FeedBackPredicao.Any(e => e.FeedBackPredicaoId == id);
        }
    }
}

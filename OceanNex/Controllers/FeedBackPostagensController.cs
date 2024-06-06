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
    public class FeedBackPostagensController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public FeedBackPostagensController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: FeedBackPostagens
        public async Task<IActionResult> Index()
        {
            var oracleFIAPDbContext = _context.FeedBackPostagem.Include(f => f.Conta).Include(f => f.Postagem);
            return View(await oracleFIAPDbContext.ToListAsync());
        }

        // GET: FeedBackPostagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = await _context.FeedBackPostagem
                .Include(f => f.Conta)
                .Include(f => f.Postagem)
                .FirstOrDefaultAsync(m => m.FeedBackPostagemId == id);
            if (feedBackPostagem == null)
            {
                return NotFound();
            }

            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email");
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "Bibliografia");
            return View();
        }

        // POST: FeedBackPostagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedBackPostagemId,StatusFeedBackPostagem,DescricaoFeedBackPostagem,ContaId,PostagemId")] FeedBackPostagem feedBackPostagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedBackPostagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPostagem.ContaId);
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "Bibliografia", feedBackPostagem.PostagemId);
            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = await _context.FeedBackPostagem.FindAsync(id);
            if (feedBackPostagem == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPostagem.ContaId);
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "Bibliografia", feedBackPostagem.PostagemId);
            return View(feedBackPostagem);
        }

        // POST: FeedBackPostagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedBackPostagemId,StatusFeedBackPostagem,DescricaoFeedBackPostagem,ContaId,PostagemId")] FeedBackPostagem feedBackPostagem)
        {
            if (id != feedBackPostagem.FeedBackPostagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedBackPostagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackPostagemExists(feedBackPostagem.FeedBackPostagemId))
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
            ViewData["ContaId"] = new SelectList(_context.Conta, "ContaId", "Email", feedBackPostagem.ContaId);
            ViewData["PostagemId"] = new SelectList(_context.Postagem, "PostagemId", "Bibliografia", feedBackPostagem.PostagemId);
            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = await _context.FeedBackPostagem
                .Include(f => f.Conta)
                .Include(f => f.Postagem)
                .FirstOrDefaultAsync(m => m.FeedBackPostagemId == id);
            if (feedBackPostagem == null)
            {
                return NotFound();
            }

            return View(feedBackPostagem);
        }

        // POST: FeedBackPostagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedBackPostagem = await _context.FeedBackPostagem.FindAsync(id);
            if (feedBackPostagem != null)
            {
                _context.FeedBackPostagem.Remove(feedBackPostagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackPostagemExists(int id)
        {
            return _context.FeedBackPostagem.Any(e => e.FeedBackPostagemId == id);
        }
    }
}

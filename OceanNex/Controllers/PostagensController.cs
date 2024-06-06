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
    public class PostagensController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public PostagensController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Postagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Postagem.ToListAsync());
        }

        // GET: Postagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem.Include(x => x.Biologo)
                .FirstOrDefaultAsync(m => m.PostagemId == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // GET: Postagens/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Biologo, "ContaId", "CRBio");
            return View();
        }

        // POST: Postagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostagemId,Titulo,Conteudo,Bibliografia,ContaId")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Biologo, "ContaId", "CRBio", postagem.ContaId);
            return View(postagem);
        }

        // GET: Postagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Biologo, "ContaId", "CRBio", postagem.ContaId);
            return View(postagem);
        }

        // POST: Postagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostagemId,Titulo,Conteudo,Bibliografia,ContaId")] Postagem postagem)
        {
            if (id != postagem.PostagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemExists(postagem.PostagemId))
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
            ViewData["ContaId"] = new SelectList(_context.Biologo, "ContaId", "CRBio", postagem.ContaId);
            return View(postagem);
        }

        // GET: Postagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem
                .FirstOrDefaultAsync(m => m.PostagemId == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // POST: Postagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagem = await _context.Postagem.FindAsync(id);
            if (postagem != null)
            {
                _context.Postagem.Remove(postagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemExists(int id)
        {
            return _context.Postagem.Any(e => e.PostagemId == id);
        }
    }
}

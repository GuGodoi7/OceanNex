using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OceanNex.Models;
using OceanNex.Persistencia;
using OceanNex.Persistencia.Repositorios.Interfaces;

namespace OceanNex.Controllers
{
    public class FeedBackPostagensController : Controller
    {
        private readonly IRepositorio<FeedBackPostagem> _feedBackPostagemRepositorio;

        public FeedBackPostagensController(IRepositorio<FeedBackPostagem> feedBackPostagemRepositorio)
        {
            _feedBackPostagemRepositorio = feedBackPostagemRepositorio;
        }

        // GET: FeedBackPostagens
        public async Task<IActionResult> Index()
        {
            return View(_feedBackPostagemRepositorio.GetAll());
        }

        // GET: FeedBackPostagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = _feedBackPostagemRepositorio.GetById(id);
            if (feedBackPostagem == null)
            {
                return NotFound();
            }

            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeedBackPostagens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedBackPostagemId,StatusFeedBackPostagem,DescricaoFeedBackPostagem")] FeedBackPostagem feedBackPostagem)
        {
            if (ModelState.IsValid)
            {
                _feedBackPostagemRepositorio.Add(feedBackPostagem);
                return RedirectToAction(nameof(Index));
            }
            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = _feedBackPostagemRepositorio.GetById(id);
            if (feedBackPostagem == null)
            {
                return NotFound();
            }
            return View(feedBackPostagem);
        }

        // POST: FeedBackPostagens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedBackPostagemId,StatusFeedBackPostagem,DescricaoFeedBackPostagem")] FeedBackPostagem feedBackPostagem)
        {
            if (id != feedBackPostagem.FeedBackPostagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _feedBackPostagemRepositorio.Update(feedBackPostagem);
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
            return View(feedBackPostagem);
        }

        // GET: FeedBackPostagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPostagem = _feedBackPostagemRepositorio.GetById(id);
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
            var feedBackPostagem = _feedBackPostagemRepositorio.GetById(id);
            if (feedBackPostagem != null)
            {
                _feedBackPostagemRepositorio.Delete(feedBackPostagem);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackPostagemExists(int id)
        {
            return _feedBackPostagemRepositorio.GetById(id) is not null;
        }
    }
}

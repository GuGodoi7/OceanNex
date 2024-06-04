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
    public class FeedBackPredicoesController : Controller
    {
        private readonly IRepositorio<FeedBackPredicao> _feedBackPredicaoRepositorio;

        public FeedBackPredicoesController(IRepositorio<FeedBackPredicao> feedBackPredicaoRepositorio)
        {
            _feedBackPredicaoRepositorio = feedBackPredicaoRepositorio;
        }

        // GET: FeedBackPredicoes
        public async Task<IActionResult> Index()
        {
            return View(_feedBackPredicaoRepositorio.GetAll());
        }

        // GET: FeedBackPredicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = _feedBackPredicaoRepositorio.GetById(id);
            if (feedBackPredicao == null)
            {
                return NotFound();
            }

            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Create
        public IActionResult Create()
        {
            ViewData["PredicaoId"] = new SelectList(_feedBackPredicaoRepositorio.GetAll(), "PredicaoId", "DescricaoPredicao");
            return View();
        }

        // POST: FeedBackPredicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedBackPredicaoId,StatusFeedBackPredicao,DescricaoFeedBackPredicao,PredicaoId")] FeedBackPredicao feedBackPredicao)
        {
            if (ModelState.IsValid)
            {
                _feedBackPredicaoRepositorio.Add(feedBackPredicao);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PredicaoId"] = new SelectList(_feedBackPredicaoRepositorio.GetAll(), "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = _feedBackPredicaoRepositorio.GetById(id);
            if (feedBackPredicao == null)
            {
                return NotFound();
            }
            ViewData["PredicaoId"] = new SelectList(_feedBackPredicaoRepositorio.GetAll(), "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // POST: FeedBackPredicoes/Edit/5
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedBackPredicaoId,StatusFeedBackPredicao,DescricaoFeedBackPredicao,PredicaoId")] FeedBackPredicao feedBackPredicao)
        {
            if (id != feedBackPredicao.FeedBackPredicaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _feedBackPredicaoRepositorio.Update(feedBackPredicao);
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
            ViewData["PredicaoId"] = new SelectList(_feedBackPredicaoRepositorio.GetAll(), "PredicaoId", "DescricaoPredicao", feedBackPredicao.PredicaoId);
            return View(feedBackPredicao);
        }

        // GET: FeedBackPredicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBackPredicao = _feedBackPredicaoRepositorio.GetById(id);
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
            var feedBackPredicao = _feedBackPredicaoRepositorio.GetById(id);
            if (feedBackPredicao != null)
            {
                _feedBackPredicaoRepositorio.Delete(feedBackPredicao);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackPredicaoExists(int id)
        {
            return _feedBackPredicaoRepositorio.GetById(id) is not null;
        }
    }
}

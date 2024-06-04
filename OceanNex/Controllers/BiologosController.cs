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
    public class BiologosController : Controller
    {
        private readonly IRepositorio<Biologo> _biologoRepositorio;

        public BiologosController(IRepositorio<Biologo> biologoRepositorio)
        {
            _biologoRepositorio = biologoRepositorio;
        }

        // GET: Biologos
        public async Task<IActionResult> Index()
        {
            return View(_biologoRepositorio.GetAll());
        }

        // GET: Biologos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = _biologoRepositorio.GetById(id);
              
            if (biologo == null)
            {
                return NotFound();
            }

            return View(biologo);
        }

        // GET: Biologos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biologos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiologoId,NumeroRegistro,CPF,CRBio,ContaId,NomeConta,Email,Senha")] Biologo biologo)
        {
            if (ModelState.IsValid)
            {
                _biologoRepositorio.Add(biologo);
                return RedirectToAction(nameof(Index));
            }
            return View(biologo);
        }

        // GET: Biologos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = _biologoRepositorio.GetById(id);
            if (biologo == null)
            {
                return NotFound();
            }
            return View(biologo);
        }

        // POST: Biologos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroRegistro,CPF,CRBio,ContaId,NomeConta,Email,Senha")] Biologo biologo)
        {
            if (id != biologo.ContaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _biologoRepositorio.Update(biologo);
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

        // GET: Biologos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologo = _biologoRepositorio.GetById(id);
            if (biologo == null)
            {
                return NotFound();
            }

            return View(biologo);
        }

        // POST: Biologos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biologo = _biologoRepositorio.GetById(id);
            if (biologo != null)
            {
                _biologoRepositorio.Delete(biologo);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BiologoExists(int id)
        {
            return _biologoRepositorio.GetById(id) is not null;
        }
    }
}

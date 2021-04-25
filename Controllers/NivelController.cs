using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismul_In_Capitalele_Europene.Services.ImplementationServices;
using Turismul_In_Capitalele_Europene.Models;
using Microsoft.AspNetCore.Authorization;

namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class NivelController : Controller
    {
        private readonly NivelService nivelService;

        public NivelController(NivelService nivelService)
        {
            this.nivelService = nivelService;
        }

        // GET: Nivels
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {
            var nivele = nivelService.GetAllNivels();
            return View(nivele);
        }

        // GET: Nivels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = nivelService.GetDetailsById(id);
            if (nivel == null)
            {
                return NotFound();
            }

            return View(nivel);
        }

        // GET: Nivels/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nivels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NivelId,Denumire,Punctaj_min,Punctaj_max")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                nivelService.Create(nivel);
                return RedirectToAction(nameof(Index));
            }
            return View(nivel);
        }

        // GET: Nivels/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = nivelService.GetDetailsById(id);
            if (nivel == null)
            {
                return NotFound();
            }
            return View(nivel);
        }

        // POST: Nivels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NivelId,Denumire,Punctaj_min,Punctaj_max")] Nivel nivel)
        {
            if (id != nivel.NivelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nivelService.UpdateNivel(nivel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nivelService.NivelExists(nivel.NivelId))
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
            return View(nivel);
        }

        // GET: Nivels/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivel = nivelService.GetDetailsById(id);
            if (nivel == null)
            {
                return NotFound();
            }

            return View(nivel);
        }

        // POST: Nivels/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            nivelService.DeleteNivel(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

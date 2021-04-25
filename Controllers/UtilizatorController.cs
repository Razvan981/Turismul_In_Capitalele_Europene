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
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class UtilizatorController : Controller
    {
        private readonly UtilizatorService utilizatorService;

        public UtilizatorController(UtilizatorService utilizatorService)
        {
            this.utilizatorService = utilizatorService;
        }

        // GET: Utilizators
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            utilizatorService.UpdateTabelUtilizatori();
            var utilizatori = utilizatorService.GetAllUtilizatori();
            return View(utilizatori);
        }

        // GET: Utilizators/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = utilizatorService.GetDetailsById(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            return View(utilizator);
        }

        // GET: Utilizators/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Email,Telefon,Parola,Numar_Intrebari,Numar_Raspunsuri")] Utilizator utilizator)
        {
            if (ModelState.IsValid)
            {
                utilizatorService.Create(utilizator);
                return RedirectToAction(nameof(Index));
            }
            return View(utilizator);
        }

        // GET: Utilizators/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = utilizatorService.GetDetailsById(id);
            if (utilizator == null)
            {
                return NotFound();
            }
            return View(utilizator);
        }

        // POST: Utilizators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nume,Prenume,Email,Numar_Intrebari,Numar_Raspunsuri")] Utilizator utilizator)
        {
            if (id != utilizator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    utilizatorService.UpdateUtilizator(utilizator);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!utilizatorService.UtilizatorExists(utilizator.Id))
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
            return View(utilizator);
        }

        // GET: Utilizators/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizator = utilizatorService.GetDetailsById(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            return View(utilizator);
        }

        // POST: Utilizators/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            utilizatorService.DeleteUtilizator(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

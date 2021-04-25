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
    public class TuristController : Controller
    {
        private readonly TuristService turistService;       

        public TuristController(TuristService turistService)
        {
            this.turistService = turistService;
        }

        // GET: Turists
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {
            turistService.UpdateTabelTuristi();

            var turisti = turistService.GetAllTurist();
            return View(turisti);
        }

        // GET: Turists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = turistService.GetDetailsById(id);
            if (turist == null)
            {
                return NotFound();
            }

            return View(turist);
        }

        // GET: Turists/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["NivelId"] = new SelectList(turistService.GetAllNivele(), "NivelId", "Denumire");
            ViewData["UtilizatorId"] = new SelectList(turistService.GetAllUtilizatori(), "Id", "Nume");
            return View();
        }

        // POST: Turists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristId,UtilizatorId,NivelId,Locatii_Vizitate,Scor")] Turist turist)
        {
            if (ModelState.IsValid)
            {
                turistService.Create(turist);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NivelId"] = new SelectList(turistService.GetAllNivele(), "NivelId", "Denumire", turist.NivelId);
            ViewData["UtilizatorId"] = new SelectList(turistService.GetAllUtilizatori(), "Id", "Nume", turist.UtilizatorId);
            return View(turist);
        }

        // GET: Turists/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = turistService.GetDetailsById(id);
            if (turist == null)
            {
                return NotFound();
            }
            ViewData["NivelId"] = new SelectList(turistService.GetAllNivele(), "NivelId", "Denumire", turist.NivelId);
            ViewData["UtilizatorId"] = new SelectList(turistService.GetAllUtilizatori(), "Id", "Nume", turist.UtilizatorId);
            return View(turist);
        }

        // POST: Turists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristId,UtilizatorId,NivelId,Locatii_Vizitate,Scor")] Turist turist)
        {
            if (id != turist.TuristId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    turistService.UpdateTurist(turist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!turistService.TuristExists(turist.TuristId))
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
            ViewData["NivelId"] = new SelectList(turistService.GetAllNivele(), "NivelId", "Denumire", turist.NivelId);
            ViewData["UtilizatorId"] = new SelectList(turistService.GetAllUtilizatori(), "Id", "Nume", turist.UtilizatorId);
            return View(turist);
        }

        // GET: Turists/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = turistService.GetDetailsById(id);
            if (turist == null)
            {
                return NotFound();
            }

            return View(turist);
        }

        // POST: Turists/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            turistService.DeleteTurist(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

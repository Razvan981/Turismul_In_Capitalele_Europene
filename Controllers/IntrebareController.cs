using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.ImplementationServices;


namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class IntrebareController : Controller
    {
        private readonly IntrebareService intrebareService;
        private readonly UtilizatorService utilizatorService;
        private readonly UserManager<Utilizator> userManager;

        public IntrebareController(IntrebareService intrebareService, UtilizatorService utilizatorService, UserManager<Utilizator> userManager)
        {
            this.intrebareService = intrebareService;
            this.utilizatorService = utilizatorService;
            this.userManager = userManager;
        }

        // GET: Intrebares
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {

            var userId = userManager.GetUserId(User);

            ViewData["UserId"] = userId;

            var intrebari = intrebareService.GetAllIntrebari();
            return View(intrebari);
        }

        // GET: Intrebares/Details/5     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intrebare = intrebareService.GetDetailsById(id);

            if (intrebare == null)
            {
                return NotFound();
            }

            return View(intrebare);
        }

        // GET: Intrebares/Create
        public async Task<IActionResult> Create()
        {
            var utilizator = await utilizatorService.GetCurrentUser(HttpContext.User);

            return View();
        }

        // POST: Intrebares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntrebareId,Data,Continut")] Intrebare intrebare)
        {
            var utilizator = await utilizatorService.GetCurrentUser(HttpContext.User);

            if (ModelState.IsValid)
            {              
                intrebareService.Create(intrebare, utilizator);
                return RedirectToAction(nameof(Index));
            }

            return View(intrebare);
        }

        // GET: Intrebares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intrebare = intrebareService.GetDetailsById(id);

            if (intrebare == null)
            {
                return NotFound();
            }
            ViewData["UtilizatorId"] = new SelectList(intrebareService.GetAllUtilizatori(), "Id", "Nume", intrebare.UtilizatorId);
            return View(intrebare);
        }

        // POST: Intrebares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntrebareId,UtilizatorId,Data,Continut")] Intrebare intrebare)
        {
            if (id != intrebare.IntrebareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    intrebareService.UpdateIntrebare(intrebare);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!intrebareService.IntrebareExists(intrebare.IntrebareId))
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
            ViewData["UtilizatorId"] = new SelectList(intrebareService.GetAllUtilizatori(), "Id", "Nume", intrebare.UtilizatorId);
            return View(intrebare);
        }

        // GET: Intrebares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intrebare = intrebareService.GetDetailsById(id);

            if (intrebare == null)
            {
                return NotFound();
            }

            return View(intrebare);
        }

        // POST: Intrebares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            intrebareService.DeleteIntrebare(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

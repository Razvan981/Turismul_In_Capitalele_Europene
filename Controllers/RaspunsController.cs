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
    public class RaspunsController : Controller
    {
        private readonly RaspunsService raspunsService;
        private readonly UtilizatorService utilizatorService;
        private readonly UserManager<Utilizator> userManager;

        public RaspunsController(RaspunsService raspunsService, UtilizatorService utilizatorService, UserManager<Utilizator> userManager)
        {
            this.raspunsService = raspunsService;
            this.utilizatorService = utilizatorService;
            this.userManager = userManager;
        }

        // GET: Raspuns
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {

            var userId = userManager.GetUserId(User);

            ViewData["UserId"] = userId;

            var raspunsuri = raspunsService.GetAllRaspunsuri();
            return View(raspunsuri);
        }

        // GET: Raspuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspuns = raspunsService.GetDetailsById(id);
            if (raspuns == null)
            {
                return NotFound();
            }

            return View(raspuns);
        }

        // GET: Raspuns/Create
        public IActionResult Create()
        {
            ViewData["IntrebareId"] = new SelectList(raspunsService.GetAllIntrebari(), "IntrebareId", "Continut");
            return View();
        }

        // POST: Raspuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaspunsId,IntrebareId,Data,Continut")] Raspuns raspuns)
        {
            var utilizator = await utilizatorService.GetCurrentUser(HttpContext.User);

            if (ModelState.IsValid)
            {
                raspunsService.Create(raspuns, utilizator);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IntrebareId"] = new SelectList(raspunsService.GetAllIntrebari(), "IntrebareId", "Continut", raspuns.IntrebareId);         
            return View(raspuns);
        }

        // GET: Raspuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspuns = raspunsService.GetDetailsById(id);

            if (raspuns == null)
            {
                return NotFound();
            }
            ViewData["IntrebareId"] = new SelectList(raspunsService.GetAllIntrebari(), "IntrebareId", "Continut", raspuns.IntrebareId);
            ViewData["UtilizatorId"] = new SelectList(raspunsService.GetAllUtilizatori(), "Id", "Nume", raspuns.UtilizatorId);
            return View(raspuns);
        }

        // POST: Raspuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RaspunsId,IntrebareId,UtilizatorId,Data,Continut")] Raspuns raspuns)
        {
            if (id != raspuns.RaspunsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    raspunsService.UpdateRaspuns(raspuns);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!raspunsService.RaspunsExists(raspuns.RaspunsId))
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
            ViewData["IntrebareId"] = new SelectList(raspunsService.GetAllIntrebari(), "IntrebareId", "Continut", raspuns.IntrebareId);
            ViewData["UtilizatorId"] = new SelectList(raspunsService.GetAllUtilizatori(), "Id", "Nume", raspuns.UtilizatorId);
            return View(raspuns);
        }

        // GET: Raspuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspuns = raspunsService.GetDetailsById(id);
            if (raspuns == null)
            {
                return NotFound();
            }

            return View(raspuns);
        }

        // POST: Raspuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            raspunsService.DeleteRaspuns(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

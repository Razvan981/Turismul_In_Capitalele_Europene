using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismul_In_Capitalele_Europene.Services.ImplementationServices;
using Turismul_In_Capitalele_Europene.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class CapitalaTuristController : Controller
    {
        private readonly CapitalaTuristService capitalaTuristService;
        private readonly UtilizatorService utilizatorService;
        private readonly UserManager<Utilizator> userManager;

        public CapitalaTuristController(CapitalaTuristService capitalaTuristService, UtilizatorService utilizatorService, UserManager<Utilizator> userManager)
        {
            this.capitalaTuristService = capitalaTuristService;
            this.utilizatorService = utilizatorService;
            this.userManager = userManager;
        }

        // GET: CapitalaTurists
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);

            ViewData["UserId"] = userId;

            var capitala_turisti = capitalaTuristService.GetAllCapitalaTurist();
            return View(capitala_turisti);
        }

        // GET: CapitalaTurists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitalaTurist = capitalaTuristService.GetDetailsById(id);

            if (capitalaTurist == null)
            {
                return NotFound();
            }

            return View(capitalaTurist);
        }

        // GET: CapitalaTurists/Create
        public IActionResult Create()
        {
            ViewData["CapitalaId"] = new SelectList(capitalaTuristService.GetAllCapitala(), "CapitalaId", "Denumire");
            ViewData["TuristId"] = new SelectList(capitalaTuristService.GetAllTuristi(), "TuristId", "Utilizator.Nume");
            return View();
        }

        // POST: CapitalaTurists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapitalaTuristId,CapitalaId,TuristId,Zile_Petrecute,Calificativ_Acordat")] CapitalaTurist capitalaTurist)
        {
            if (ModelState.IsValid)
            {
                capitalaTuristService.Create(capitalaTurist);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalaId"] = new SelectList(capitalaTuristService.GetAllCapitala(), "CapitalaId", "Denumire");
            ViewData["TuristId"] = new SelectList(capitalaTuristService.GetAllTuristi(), "TuristId", "Utilizator.Nume");
            return View(capitalaTurist);
        }

        // GET: CapitalaTurists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitalaTurist = capitalaTuristService.GetDetailsById(id);

            if (capitalaTurist == null)
            {
                return NotFound();
            }
            ViewData["CapitalaId"] = new SelectList(capitalaTuristService.GetAllCapitala(), "CapitalaId", "Denumire");
            ViewData["TuristId"] = new SelectList(capitalaTuristService.GetAllTuristi(), "TuristId", "TuristId");
            return View(capitalaTurist);
        }

        // POST: CapitalaTurists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapitalaTuristId,CapitalaId,TuristId,Zile_Petrecute,Calificativ_Acordat")] CapitalaTurist capitalaTurist)
        {
            if (id != capitalaTurist.CapitalaTuristId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    capitalaTuristService.UpdateCapitalaTurist(capitalaTurist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!capitalaTuristService.CapitalaTuristExists(capitalaTurist.CapitalaTuristId))
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
            ViewData["CapitalaId"] = new SelectList(capitalaTuristService.GetAllCapitala(), "CapitalaId", "Denumire");
            ViewData["TuristId"] = new SelectList(capitalaTuristService.GetAllTuristi(), "TuristId", "TuristId");
            return View(capitalaTurist);
        }

        // GET: CapitalaTurists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var capitalaTurist = capitalaTuristService.GetDetailsById(id);
            if (capitalaTurist == null)
            {
                return NotFound();
            }

            return View(capitalaTurist);
        }

        // POST: CapitalaTurists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            capitalaTuristService.DeleteCapitalaTurist(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

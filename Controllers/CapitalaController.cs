using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismul_In_Capitalele_Europene.Services.ImplementationServices;
using Turismul_In_Capitalele_Europene.Models;
using Microsoft.AspNetCore.Authorization;

namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class CapitalaController : Controller
    {
        private readonly CapitalaService capitalaService;

        public CapitalaController(CapitalaService capitalaService)
        {
            this.capitalaService = capitalaService;
        }

        // GET: ControllerCapitale
        [Authorize(Roles = "Administrator , Utilizator")]
        public async Task<IActionResult> Index()
        {
            var capitale = capitalaService.GetAllCapitals();
            return View(capitale);
        }

        // GET: ControllerCapitale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitala = capitalaService.GetDetailsById(id);
            var densitate = capitalaService.GetDensitate(capitala);
            if (capitala == null)
            {
                return NotFound();
            }
            ViewData["Densitate"] = densitate;
            return View(capitala);
        }


        // GET: ControllerCapitale/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControllerCapitale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapitalaId,Denumire,Tara,Regiune,Fondare_secol,Populatie,Suprafata_kmp")] Capitala capitala)
        {
            if (ModelState.IsValid)
            {
                capitalaService.Create(capitala);
                return RedirectToAction(nameof(Index));
            }
            return View(capitala);
        }

        // GET: ControllerCapitale/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var capitala = capitalaService.GetDetailsById(id);
            if (capitala == null)
            {
                return NotFound();
            }
            return View(capitala);
        }

        // POST: ControllerCapitale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapitalaId,Denumire,Tara,Regiune,Fondare_secol,Populatie,Suprafata_kmp")] Capitala capitala)
        {
            if (id != capitala.CapitalaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    capitalaService.UpdateCapitala(capitala);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!capitalaService.CapitalaExists(capitala.CapitalaId))
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
            return View(capitala);
        }

        // GET: ControllerCapitale/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var capitala = capitalaService.GetDetailsById(id);
            if (capitala == null)
            {
                return NotFound();
            }

            return View(capitala);
        }

        // POST: ControllerCapitale/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            capitalaService.DeleteCapitala(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

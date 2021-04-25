using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<Utilizator> userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<Utilizator> userManager)
        {
            _logger = logger;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViziteazaLondra()
        {
            return View();
        }

        public IActionResult ViziteazaMadrid()
        {
            return View();
        }

        public IActionResult ViziteazaRoma()
        {
            return View();
        }

        public IActionResult ViziteazaParis()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<FileContentResult> Imagine()
        {
            var user = await userManager.GetUserAsync(User);
            if (user.Imagine != null)
                return new FileContentResult(user.Imagine, "image/jpeg");
            else
                return new FileContentResult(new byte[0], "image/jpeg");
        }

    }
}

using AspNetCoreUIMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreUIMVC.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HashSet<string> AllowedViews = new(StringComparer.OrdinalIgnoreCase)
        {
            "Index",
            "Charts",
            "Buttons",
            "Forms",
            "Tables",
            "Typography",
            "Icons",
            "Dashboard",
            "Widgets",
        };

        [HttpGet("{view?}")]
        public IActionResult Index(string view = "Index")
        {
            if (!AllowedViews.Contains(view))
                return NotFound();

            ViewData["Title"] = $"CoreUI - {view}";

            return View(view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

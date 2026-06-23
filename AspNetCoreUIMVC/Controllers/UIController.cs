using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreUIMVC.Controllers
{
    [Route("UI")]
    public class UIController : Controller
    {
        private static readonly HashSet<string> AllowedUIViews = new(StringComparer.OrdinalIgnoreCase)
        {
            "Charts",
            "Buttons",
            "Forms",
            "Tables",
            "Typography",
            "Icons",
            "Widgets",
            "components/accordion",
            "components/alerts",
            "components/badge",
            "components/breadcrumb",
            "components/buttons",
            "components/buttongroup",
            "components/cards",
            "components/carousel",
            "components/chip",
            "components/collapse",
            "components/dropdowns",
            "components/form",
            "components/inputgroup",
            "components/jumbotron",
            "components/listgroup",
            "components/media-object",
            "components/modals",
            "components/navstabs",
            "components/navbar",
            "components/pagination",
            "components/placeholders",
            "components/popovers",
            "components/progress",
            "components/spinners",
            "components/tables",
            "components/toasts",
            "components/tooltips"
        };

        [HttpGet("/UI/{*view}")]
        public IActionResult RenderView(string view)
        {
            if (!AllowedUIViews.Contains(view))
                return NotFound();

            string pageName = view.Substring(view.LastIndexOf('/') + 1);
            ViewData["Title"] = $"CoreUI - {char.ToUpper(pageName[0]) + pageName.Substring(1)}";
            return View($"~/Views/UI/{view}.cshtml");
        }
    }
}

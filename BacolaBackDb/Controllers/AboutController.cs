using Microsoft.AspNetCore.Mvc;

namespace BacolaBackDb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "About";
            ViewBag.Javascript = "about";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BacolaBackDb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Contact";
            ViewBag.Javascript = "contac";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BacolaBackDb.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Blog";
            ViewBag.Javascript = "blog";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BacolaBackDb.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Cart";
            ViewBag.Javascript = "cart";
            return View();
        }
    }
}

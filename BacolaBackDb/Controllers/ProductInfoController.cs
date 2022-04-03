using Microsoft.AspNetCore.Mvc;

namespace BacolaBackDb.Controllers
{
    public class ProductInfoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Product Info";
            ViewBag.Javascript = "product-info";
            return View();
        }
    }
}

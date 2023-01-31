using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.Products.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

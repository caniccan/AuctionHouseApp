using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

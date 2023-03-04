using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.UI.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using AuctionHouse.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.UI.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            List<AuctionViewModel> viewModelList = new List<AuctionViewModel>();
            return View(viewModelList);
        }
    }
}

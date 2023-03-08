using AuctionHouse.Core.Repositories;
using AuctionHouse.UI.Clients;
using AuctionHouse.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.UI.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
        }

        public IActionResult Index()
        {
            return View(new List<AuctionViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var productList = await _productClient.GetProducts();
            if (productList.IsSuccess)
            {
                ViewBag.ProductList = productList.Data;
            }

            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuctionViewModel model)
        {
            return View(model);
        }

        public IActionResult Detail()
        {

            return View();
        }
    }
}

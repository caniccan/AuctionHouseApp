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
        private readonly AuctionClient _auctionClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient, AuctionClient auctionClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _auctionClient = auctionClient;
        }

        public async Task<IActionResult> Index()
        {
            var AuctionList = await _auctionClient.GetAuctions();
            if (AuctionList.IsSuccess)
            {
                return View(AuctionList.Data);
            }
            return View();
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
        public async Task<IActionResult> Create(AuctionViewModel model)
        {
            model.Id = model.Id ?? string.Empty;
            model.Status = 1;
            model.CreatedAt = DateTime.Now;
            model.IncludedSellers.Add(model.SellerId);
            var createAuction = await _auctionClient.CreateAuction(model);
            if (createAuction.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Detail()
        {

            return View();
        }
    }
}

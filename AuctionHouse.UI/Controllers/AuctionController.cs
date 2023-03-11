using AuctionHouse.Core.Repositories;
using AuctionHouse.Core.ResultModels;
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
        private readonly BidClient _bidClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient, AuctionClient auctionClient, BidClient bidClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _auctionClient = auctionClient;
            _bidClient = bidClient;
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

        public async Task<IActionResult> Detail(string id)
        {
            var model=new AuctionBidsViewModel();
            var auctionResponse = await _auctionClient.GetAuctionById(id);
            var bidsResponse = await _bidClient.GetAllBidsByAuctionId(id);

            model.SellerUserName = HttpContext.User?.Identity.Name;
            model.AuctionId = auctionResponse.Data.Id;
            model.ProductId= auctionResponse.Data.ProductId;
            model.Bids = bidsResponse.Data;

            return View(model);
        }

        [HttpPost]
        public async Task<Result<string>> SendBid(BidViewModel model)
        {
            
            model.CreatedAt = DateTime.Now;
            var sendBidResponse = await _bidClient.SendBid(model);
            return sendBidResponse;
        }
    }
}

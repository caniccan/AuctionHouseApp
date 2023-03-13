using AuctionHouse.Core.Common;
using AuctionHouse.Core.ResultModels;
using AuctionHouse.UI.ViewModels;
using Newtonsoft.Json;

namespace AuctionHouse.UI.Clients
{
    /// <summary>
    /// BidClient
    /// </summary>
    public class BidClient
    {
        /// <summary>
        /// Client
        /// </summary>
        public HttpClient _client { get; }

        /// <summary>
        /// BidClient Constructor
        /// </summary>
        /// <param name="client"></param>
        public BidClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.LocalAuctionBaseAddress);
        }

        /// <summary>
        /// GetAllBidsByAuctionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<List<BidViewModel>>> GetAllBidsByAuctionId(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Bid/GetBidByActionId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<BidViewModel>>(responseData);
                if (result.Any())
                {
                    return new Result<List<BidViewModel>>(true, ResultConstant.RecordFound, result.ToList());
                }
            }
            return new Result<List<BidViewModel>>(false, ResultConstant.RecordNotFound);
        }

        /// <summary>
        /// SendBid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<string>> SendBid(BidViewModel model)
        {
            model.Id = "";
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/api/v1/Bid", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<string>(true, ResultConstant.RecordCreateSuccessfully, responseData);
            }
            return new Result<string>(false, ResultConstant.RecordCreateNotSuccessfully);
        }
    }
}

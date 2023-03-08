using AuctionHouse.Core.Common;
using AuctionHouse.Core.ResultModels;
using AuctionHouse.UI.ViewModels;
using Newtonsoft.Json;

namespace AuctionHouse.UI.Clients
{
    public class ProductClient
    {
        public HttpClient _client { get; }

        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.LocalProductBaseAddress);
        }

        public async Task<Result<List<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/api/v1/Product");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result.Any())
                {
                    return new Result<List<ProductViewModel>>(true, ResultConstant.RecordFound, result.ToList());
                }
            }
            return new Result<List<ProductViewModel>>(false, ResultConstant.RecordNotFound);
        }

    }
}

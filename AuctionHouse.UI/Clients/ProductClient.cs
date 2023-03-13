using AuctionHouse.Core.Common;
using AuctionHouse.Core.ResultModels;
using AuctionHouse.UI.ViewModels;
using Newtonsoft.Json;

namespace AuctionHouse.UI.Clients
{
    /// <summary>
    /// ProductClient
    /// </summary>
    public class ProductClient
    {
        /// <summary>
        /// Client
        /// </summary>
        public HttpClient _client { get; }

        /// <summary>
        /// ProductClient Constructor
        /// </summary>
        /// <param name="client"></param>
        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/Product");
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

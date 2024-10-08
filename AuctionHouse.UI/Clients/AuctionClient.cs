﻿using AuctionHouse.Core.Common;
using AuctionHouse.Core.ResultModels;
using AuctionHouse.UI.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AuctionHouse.UI.Clients
{
    /// <summary>
    /// AuctionClient
    /// </summary>
    public class AuctionClient
    {
        /// <summary>
        /// Client
        /// </summary>
        public HttpClient _client { get; }

        /// <summary>
        /// AuctionClient Constructor
        /// </summary>
        /// <param name="client"></param>
        public AuctionClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        /// <summary>
        /// GetAuctions
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<AuctionViewModel>>> GetAuctions()
        {
            var response = await _client.GetAsync("/Auction");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<List<AuctionViewModel>>(responseData);
                if (result.Any())
                {
                    return new Result<List<AuctionViewModel>>(true, ResultConstant.RecordFound, result.ToList());
                }
            }
            return new Result<List<AuctionViewModel>>(false, ResultConstant.RecordNotFound);
        }

        /// <summary>
        /// GetAuctionById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<AuctionViewModel>> GetAuctionById(string id)
        {
            var response = await _client.GetAsync("/Auction/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseData=await response.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<AuctionViewModel>(responseData);
                if (!Equals(result,null))
                {
                    return new Result<AuctionViewModel>(true, ResultConstant.RecordFound, result);
                }
            }
            return new Result<AuctionViewModel>(false, ResultConstant.RecordNotFound);
        }

        /// <summary>
        /// CreateAuction
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<AuctionViewModel>> CreateAuction(AuctionViewModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content= new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Auction", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuctionViewModel>(responseData);
                if (!result.Equals(null))
                {
                    return new Result<AuctionViewModel>(true, ResultConstant.RecordCreateSuccessfully, result);
                }
            }
            return new Result<AuctionViewModel>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

        /// <summary>
        /// CompleteBid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<string>> CompleteBid(string id)
        {
            var dataAsString = JsonConvert.SerializeObject(id);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Auction/CompleteAuction", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return new Result<string>(true, ResultConstant.RecordCreateSuccessfully, responseData);
            }
            return new Result<string>(false, ResultConstant.RecordCreateNotSuccessfully);
        }
    }
}

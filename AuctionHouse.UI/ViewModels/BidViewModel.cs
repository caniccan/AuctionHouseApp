namespace AuctionHouse.UI.ViewModels
{
    /// <summary>
    /// BidViewModel
    /// </summary>
    public class BidViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// SellerUserName
        /// </summary>
        public string SellerUserName { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}

namespace AuctionHouse.UI.ViewModels
{
    /// <summary>
    /// AuctionBidsViewModel
    /// </summary>
    public class AuctionBidsViewModel
    {
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
        /// IsAdmin
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Bids
        /// </summary>
        public List<BidViewModel> Bids { get; set; }
    }
}

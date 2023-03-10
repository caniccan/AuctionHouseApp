using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.UI.ViewModels
{
    /// <summary>
    /// AuctionViewModel
    /// </summary>
    public class AuctionViewModel
    {
        /// <summary>
        /// AuctionViewModel Constructor
        /// </summary>
        public AuctionViewModel()
        {
            IncludedSellers = new List<string>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage ="Please fill Name")]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = "Please fill Description")]
        public string Description { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        [Required(ErrorMessage = "Please fill Product")]
        public string ProductId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Required(ErrorMessage = "Please fill Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// StartedAt
        /// </summary>
        [Required(ErrorMessage = "Please fill Start Date")]
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// FinishedAt
        /// </summary>
        [Required(ErrorMessage = "Please fill Finished Date")]
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// SellerId
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// IncludedSellers
        /// </summary>
        public List<string> IncludedSellers { get; set; }
    }
}

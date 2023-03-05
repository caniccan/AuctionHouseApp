﻿using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.UI.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please fill Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please fill Product")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Please fill Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please fill Start Date")]
        public DateTime StartedAt { get; set; }

        [Required(ErrorMessage = "Please fill Finished Date")]
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public int SellerId { get; set; }
        public List<string> IncludedSellers { get; set; }
    }
}

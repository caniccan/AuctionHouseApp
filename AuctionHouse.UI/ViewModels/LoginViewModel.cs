﻿using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.UI.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "The password must be at least 4 characters.")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}

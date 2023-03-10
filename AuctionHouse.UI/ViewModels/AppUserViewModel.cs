using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.UI.ViewModels
{
    /// <summary>
    /// AppUserViewModel
    /// </summary>
    public class AppUserViewModel
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage ="Username is required")]
        [Display(Name ="User Name")]
        public string Username { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        [Required(ErrorMessage = "FirstName is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [Required(ErrorMessage = "LastName is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// IsBuyer
        /// </summary>
        [Required(ErrorMessage = "Buyer is required")]
        [Display(Name = "Is Buyer")]
        public bool IsBuyer { get; set; }

        /// <summary>
        /// IsSeller
        /// </summary>
        [Required(ErrorMessage = "Seller is required")]
        [Display(Name = "Is Seller")]
        public bool IsSeller { get; set; }

        /// <summary>
        /// UserSelectTypeId
        /// </summary>
        public int UserSelectTypeId { get; set; }
    }
}

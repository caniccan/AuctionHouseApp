using AuctionHouse.Core.Entities;
using AuctionHouse.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.UI.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (!Equals(user,null))
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email address or password is not valid");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email address or password is not valid");
                }
            }
            return View(loginModel);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserViewModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    FirstName = signUpModel.FirstName,
                    Email = signUpModel.Email,
                    LastName = signUpModel.LastName,
                    PhoneNumber = signUpModel.PhoneNumber,
                    UserName = signUpModel.Username,
                };

                if (signUpModel.UserSelectTypeId.Equals(1))
                {
                    user.IsBuyer = true;
                    user.IsSeller = false;
                }
                else
                {
                    user.IsSeller = true;
                    user.IsBuyer = false;
                }

                var result = await _userManager.CreateAsync(user,signUpModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(signUpModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

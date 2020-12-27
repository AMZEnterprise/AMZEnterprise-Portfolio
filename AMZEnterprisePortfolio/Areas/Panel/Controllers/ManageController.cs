using AMZEnterprisePortfolio.Areas.Panel.Models.ViewModels;
using AMZEnterprisePortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ManageController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordHasher<User> passwordHasher
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVm userLoginVm, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userLoginVm.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginVm.Password,
                        userLoginVm.RememberMe, false);

                    if (result.Succeeded)
                    {
                        ViewBag.returnUrl = returnUrl;
                        return Redirect(returnUrl ?? "/");
                    }
                }
            }

            return View(userLoginVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userEditVm = new UserEditVm()
            {
                Id = user.Id,
                UserName = user.UserName
            };

            return View(userEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserEditVm userEditVm)
        {
            if (id != userEditVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userEditVm.Id);

                if (user == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrWhiteSpace(userEditVm.Password))
                {
                    var removePassResult = await _userManager.RemovePasswordAsync(user);

                    if (!removePassResult.Succeeded)
                    {
                        foreach (var error in removePassResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(userEditVm);
                    }

                    user.PasswordHash = _passwordHasher.HashPassword(user, userEditVm.Password);
                }

                user.UserName = userEditVm.UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Redirect("/Panel");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(userEditVm);
            }

            return View(userEditVm);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static entity.concretes.identity.RoleTable;

using ui.Models;
using entity.concretes.identity;

namespace ui.Controllers
{
    [Controller]
    public class AuthorizetionController : Controller
    {
        private UserManager<UserTable> userManager;
        private SignInManager<UserTable> signInManager;
        private RoleManager<RoleTable> roleManager;

        public AuthorizetionController(UserManager<UserTable> userManager, SignInManager<UserTable> signInManager, RoleManager<RoleTable> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) { return View("Login", model); }
            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (!signInResult.Succeeded) { return View("Login", model); }

            if (userManager.IsInRoleAsync(user, RolesEnum.DEVELOPER.ToString()).Result) { return Redirect("/Developer/listuser"); }
            if (userManager.IsInRoleAsync(user, RolesEnum.ADMINISTRATOR.ToString()).Result) { return Redirect(url: model.Redirect ?? "/Developer/listuser"); }


            return Redirect(url: model.Redirect ?? "/Developer/listuser");
        }

        public IActionResult DeveloperPanel()
        {
            return View();
        }

        
        public IActionResult Error()
        {
            return View();
        }
       
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secure.Controllers
{
    public class RolesController : Controller
    {
        public UserManager<IdentityUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;
        public RolesController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            UserManager = _userManager;
            RoleManager = _roleManager;
        }
        public async Task<IActionResult> Index()
        {
            IdentityRole AdminRole = new IdentityRole { Name = "Admin" };
            IdentityRole UserRole = new IdentityRole { Name = "User" };

            var admin = new IdentityUser {UserName = "admin@gmail.com", Email = "admin@gmail.com", EmailConfirmed = true };
            var result = await UserManager.CreateAsync(admin, "Password12345*");
            var user = new IdentityUser {UserName = "user@gmail.com", Email = "user@gmail.com", EmailConfirmed = true };
            var userResult = await UserManager.CreateAsync(user, "Password12345*");

            IdentityResult AdminRoleResult = await RoleManager.CreateAsync(AdminRole);
            IdentityResult UserRoleResult = await RoleManager.CreateAsync(UserRole);

            IdentityUser foundAdmin = await UserManager.FindByIdAsync("6b2f7401-ae46-47c6-93c9-3d7df45a59d5");
            result = await UserManager.AddToRoleAsync(foundAdmin, "Admin");

            IdentityUser foundUser = await UserManager.FindByIdAsync("b1ff03e5-f2ec-4783-a8d6-d38d0b46797d");
            result = await UserManager.AddToRoleAsync(foundUser, "User");

            if (result.Succeeded)
            {
                return RedirectToPage("/");
            }
            return View();
        }
    }
}

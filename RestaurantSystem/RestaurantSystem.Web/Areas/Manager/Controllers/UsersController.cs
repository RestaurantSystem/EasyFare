namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Manager.Models.Users;
    using RestaurantSystem.Web.Infrastructure.Extensions;

    public class UsersController : ManagerBaseController
    {
        private readonly IManagerUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IManagerUserService users, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();
            var rolesa = this.roleManager.Roles;
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            return this.Ok(new ManagerUsersViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var userExists = await this.userManager.FindByIdAsync(model.UserId) != null;
            var user = await this.userManager.FindByIdAsync(model.UserId);

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details!");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            if (model.Role == WebConstants.NoRole)
            {
                var roles = await userManager.GetRolesAsync(user);
                await this.userManager.RemoveFromRolesAsync(user, roles);
                TempData.AddSuccessMessage($@"User {user.UserName} removed from role\s {string.Join(", ", roles)}!");
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to role {model.Role}!");

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
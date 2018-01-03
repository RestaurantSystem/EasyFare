namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using System.Threading.Tasks;
    using static WebConstants;

    [Area(WaiterRole)]
    [Authorize(Roles = WaiterArea)]
    public class TablesController : Controller
    {
        private readonly ITablesService tables;
        private readonly UserManager<User> users;

        public TablesController(ITablesService tables, UserManager<User> users)
        {
            this.tables = tables;
            this.users = users;
        }

        public async Task<IActionResult> Index()
        => View(await this.tables.AllAsync());

        public async Task<IActionResult> Open(string number)
        {
            var waiterId = this.users.GetUserId(User);
            var result = await this.tables.OpenTable(number, waiterId);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
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

        public async Task<IActionResult> Open(string number, string searchWord = "")
        {
            var waiterId = this.users.GetUserId(User);
            var result = await this.tables.OpenTable(number, waiterId, searchWord);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
    }
}
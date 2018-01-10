namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using RestaurantSystem.Web.Infrastructure.Extensions;
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
        => this.View(await this.tables.AllAsync());

        public async Task<IActionResult> Open(string number, string searchWord = "")
        {
            var waiterId = this.users.GetUserId(User);
            var result = await this.tables.OpenTable(number, searchWord);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.View(result);
        }

        public async Task<IActionResult> GetCheck(string tableNumber)
        {
            if (tableNumber == null)
            {
                return this.NotFound();
            }

            var result = await this.tables.GetCheck(tableNumber);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> PrintCheck(string tableNumber)
        {
            if (tableNumber == null)
            {
                return this.NotFound();
            }

            var success = await this.tables.PrintCheck(tableNumber);

            if (!success)
            {
                return this.NotFound();
            }

            TempData.AddSuccessMessage($"Successfully printed bill of table {tableNumber}!");

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
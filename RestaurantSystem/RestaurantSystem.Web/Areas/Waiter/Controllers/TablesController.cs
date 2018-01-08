namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using static WebConstants;
    using RestaurantSystem.Web.Infrastructure.Extensions;

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
            var result = await this.tables.OpenTable(number, searchWord);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        public async Task<IActionResult> GetCheck(string tableNumber)
        {
            var result = await this.tables.GetCheck(tableNumber);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> PrintCheck(string tableNumber)
        {
            var success = await this.tables.PrintCheck(tableNumber);

            if (!success)
            {
                return NotFound();
            }

            TempData.AddSuccessMessage($"Successfully printed bill of table {tableNumber}!");

            return RedirectToAction(nameof(Index));
        }
    }
}
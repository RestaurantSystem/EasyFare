namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Waiter.Contracts;
    using static WebConstants;

    [Area(WaiterRole)]
    [Authorize(Roles = WaiterArea)]
    public class TablesController : Controller
    {
        private readonly ITablesService tables;

        public TablesController(ITablesService tables)
        {
            this.tables = tables;
        }

        public async Task<IActionResult> Index()
        => View(await this.tables.AllAsync());
    }
}
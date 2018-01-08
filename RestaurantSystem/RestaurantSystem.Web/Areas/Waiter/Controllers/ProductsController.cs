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
    public class ProductsController : Controller
    {
        private readonly IWaiterProductsService products;
        private readonly UserManager<User> waiters;

        public ProductsController(IWaiterProductsService products,
            UserManager<User> waiters)
        {
            this.products = products;
            this.waiters = waiters;
        }

        public async Task<IActionResult> AddToTable(string tableNumber, int productId)
        {
            if (tableNumber == null)
            {
                return NotFound();
            }
            string waiterId = this.waiters.GetUserId(User);

            var product = await this.products.GetById(productId);

            if (product == null)
            {
                return NotFound();
            }

            var success = await this.products.AddToTable(tableNumber, productId, waiterId);

            if (!success)
            {
                return NotFound();
            }

            TempData.AddSuccessMessage($"{product.Name} successfully added to table {tableNumber}!");

            return RedirectToAction("Open", "Tables", new { number = tableNumber });
        }

        public async Task<IActionResult> Remove(string tableNumber, int productId)
        {
            if (tableNumber == null)
            {
                return NotFound();
            }

            var product = await this.products.GetById(productId);

            if (product == null)
            {
                return NotFound();
            }

            var success = await this.products.Remove(tableNumber, productId);

            if (!success)
            {
                return NotFound();
            }

            TempData.AddSuccessMessage($"{product.Name} successfully removed from table {tableNumber}!");

            return RedirectToAction("Open", "Tables", new { number = tableNumber });
        }
    }
}
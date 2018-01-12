namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Orders;
    using static WebConstants;

    [Area(CookRole)]
    //[Authorize(Roles = CookRole)]
    public class OrdersController : Controller
    {
        private readonly ICookOrdersService orders;

        public OrdersController(ICookOrdersService orders)
        {
            this.orders = orders;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductOrderListModel> orders = await this.orders.GetOrders();

            return this.Ok(orders);
        }
    }
}
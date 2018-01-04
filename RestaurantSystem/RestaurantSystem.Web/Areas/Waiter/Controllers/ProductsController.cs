namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Waiter.Contracts;
    using static WebConstants;

    [Area(WaiterRole)]
    [Authorize(Roles = WaiterArea)]
    public class ProductsController : Controller
    {
        private readonly IWaiterProductsService products;

        public ProductsController(IWaiterProductsService products)
        {
            this.products = products;
        }
    }
}
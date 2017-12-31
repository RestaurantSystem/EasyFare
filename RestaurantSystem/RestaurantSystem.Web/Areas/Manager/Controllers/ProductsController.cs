namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Manager.Models.Products;
    using RestaurantSystem.Web.Infrastructure.Extensions;

    public class ProductsController : ManagerBaseController
    {
        private readonly IManagerProductsService products;

        public ProductsController(IManagerProductsService products)
        {
            this.products = products;
        }

        public IActionResult Buy()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(productModel);
            }

            bool found = await this.products.BuyNewProductAsync(
                productModel.Name,
                productModel.Price,
                productModel.Type);

            if (!found)
            {
                TempData.AddErrorMessage($"The product {productModel.Name} already exists.");
                return this.View();
            }

            TempData.AddSuccessMessage($"The product {productModel.Name} added successfully.");
            return this.View();
        }
    }
}
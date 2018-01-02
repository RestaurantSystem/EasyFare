namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Products;
    using static WebConstants;

    [Area(CookRole)]
    [Authorize(Roles = CookRole)]
    public class ProductsController : Controller
    {
        private readonly ICookProductsService products;

        public ProductsController(ICookProductsService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index(string direction, int page = 1, string search = "")
        {
            if (direction == PageForward)
            {
                page++;
            }
            if (direction == PageBackward && page > 1)
            {
                page--;
            }

            ProductsPaginationAndSearchModel products = await this.products.GetProducts(search, page);

            products.TotalPages = (int)Math.Ceiling(((double)products.ItemsCount / CookConstants.ProductsPerPage));

            products.TotalPages = products.TotalPages == 0 ? 1 : products.TotalPages;

            if (products.TotalPages < products.Page)
            {
                products.Page = products.TotalPages;
            }

            products.Products = products.Products
                .Skip(CookConstants.IngredientsPerPage * (products.Page - 1))
                .Take(CookConstants.IngredientsPerPage)
                .ToList();

            return this.View(products);
        }
    }
}
namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;
    using RestaurantSystem.Web.Areas.Cook;
    using RestaurantSystem.Web.Areas.Manager.Models.Products;
    using RestaurantSystem.Web.Infrastructure.Extensions;
    using static WebConstants;

    public class ProductsController : ManagerBaseController
    {
        private readonly IManagerProductsService products;

        public ProductsController(IManagerProductsService products)
        {
            this.products = products;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(productModel);
            }

            bool found = await this.products.AddNewProductAsync(
                productModel.Name,
                productModel.Price,
                productModel.IsCookable,
                productModel.Type);

            if (!found)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.ProductAlreadyExist, productModel.Name));
                return this.View();
            }

            TempData.AddSuccessMessage(string.Format(ManagerConstants.ProductAddedSuccessfully, productModel.Name));
            return this.View();
        }

        public async Task<IActionResult> All(string direction, int page = 1, string search = "")
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

            products.TotalPages = (int)Math.Ceiling(((double)products.ItemsCount / CookConstants.IngredientsPerPage));

            products.TotalPages = products.TotalPages == 0 ? 1 : products.TotalPages;

            if (products.TotalPages < products.Page)
            {
                products.Page = products.TotalPages;
            }

            products.Products = products.Products
                .Skip(CookConstants.IngredientsPerPage * (products.Page - 1))
                .Take(CookConstants.IngredientsPerPage)
                .ToList();

            return this.Ok(products);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await this.products.FindByIdAsync(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(new ProductsListModel
            {
                Name = product.Name,
                Price = product.Price,
                Type = product.Type,
                IsCookable = product.IsCookable
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsListModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(Json("invalid"));
            }

            var building = await this.products.FindByIdAsync(productModel.Id);

            if (building == null)
            {
                return this.Ok(Json("Not found"));
            }

            bool sameName = false;

            if (TempData["OldName"].ToString() == productModel.Name)
            {
                sameName = true;
            }

            bool added = await this.products.EditAsync(productModel.Id, productModel.Name, productModel.Price, productModel.IsCookable, productModel.Type, sameName);

            if (!added)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.ProductAlreadyExist, productModel.Name));
                return this.Ok(added);
            }

            TempData.AddSuccessMessage(string.Format(ManagerConstants.ProductAddedSuccessfully, productModel.Name));
            return this.Ok(added);
        }
    }
}
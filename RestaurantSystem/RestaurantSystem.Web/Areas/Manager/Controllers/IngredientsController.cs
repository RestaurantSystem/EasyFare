namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Cook;
    using static WebConstants;

    public class IngredientsController : ManagerBaseController
    {
        private readonly IManagerIngredientsService ingredients;

        public IngredientsController(IManagerIngredientsService ingredients)
        {
            this.ingredients = ingredients;
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

            IngredientsPaginationAndSearchModel ingredients = await this.ingredients.GetIngredients(search, page);

            ingredients.TotalPages = (int)Math.Ceiling(((double)ingredients.ItemsCount / CookConstants.IngredientsPerPage));

            ingredients.TotalPages = ingredients.TotalPages == 0 ? 1 : ingredients.TotalPages;

            if (ingredients.TotalPages < ingredients.Page)
            {
                ingredients.Page = ingredients.TotalPages;
            }

            ingredients.Ingredients = ingredients.Ingredients
                .Skip(CookConstants.IngredientsPerPage * (ingredients.Page - 1))
                .Take(CookConstants.IngredientsPerPage)
                .ToList();

            return this.View(ingredients);
        }

        public async Task<IActionResult> Buy(int id)
        {
            var ingredient = await this.ingredients.FindByIdAsync(id);

            if (ingredient == null)
            {
                return this.NotFound();
            }

            return this.View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id, int quantityInStock)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(All));
            }

            var building = await this.ingredients.FindByIdAsync(id);

            if (building == null)
            {
                return this.NotFound();
            }

            await this.ingredients.BuyAsync(id, quantityInStock);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
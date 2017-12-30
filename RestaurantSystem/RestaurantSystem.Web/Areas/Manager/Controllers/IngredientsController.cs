namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Manager.Models.Ingredients;
    using RestaurantSystem.Web.Infrastructure.Extensions;

    public class IngredientsController : ManagerBaseController
    {
        private readonly IManagerIngredientsService ingredients;

        public IngredientsController(IManagerIngredientsService ingredients)
        {
            this.ingredients = ingredients;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIngredientModel ingredientModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(ingredientModel);
            }

            bool found = await this.ingredients.AddNewIngredientAsync(
                ingredientModel.Name,
                ingredientModel.QuantityInStock,
                ingredientModel.MinStockQuantityTreshold);

            if (found)
            {
                TempData.AddErrorMessage($"The ingredient {ingredientModel.Name} already exists.");
                return this.View();
            }

            TempData.AddSuccessMessage($"The ingredient {ingredientModel.Name} added successfully.");
            return this.View();
        }
    }
}
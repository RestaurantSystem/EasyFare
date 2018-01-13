namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Recipes;
    using static WebConstants;

    [Area(CookRole)]
    [Authorize(Roles = CookRole)]
    public class RecipesController : Controller
    {
        private readonly ICookRecipesService recipes;

        private readonly ICookProductsService products;

        private readonly ICookIngredientsService ingredients;

        public RecipesController(ICookRecipesService recipes, ICookProductsService products, ICookIngredientsService ingredients)
        {
            this.recipes = recipes;
            this.products = products;
            this.ingredients = ingredients;
        }

        public async Task<IActionResult> Edit(int productId)
        {
            RecipeEditModel recipe = await this.recipes.GetRecipeToEdit(productId);

            if (recipe == null)
            {
                return this.NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecipeEditModel recModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(recModel);
            }

            int recipeId = await this.recipes.AddRecipeIngredient(recModel.RecipeId, recModel.ProductId, recModel.IngredientId, recModel.Quantity);

            if (recipeId == 0)
            {
                return this.NotFound();
            }

            recModel = await this.recipes.GetRecipeToEdit(recModel.ProductId);
            recModel.RecipeId = recipeId;

            return this.View(recModel);
        }

        public IActionResult UpdateRecipeIngredients(int? id)
        {
            return ViewComponent("IncludedIngredients", new { id = id });
        }

        public async Task DeleteRecipeIngredients(int recipeId, int[] ingredientsIds)
        {
            await this.recipes.DeleteIngredients(recipeId, ingredientsIds);
        }
    }
}
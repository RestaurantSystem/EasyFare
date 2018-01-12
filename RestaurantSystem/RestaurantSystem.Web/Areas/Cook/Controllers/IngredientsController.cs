namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Ingredients;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using static WebConstants;

    [Area(CookRole)]
    //[Authorize(Roles = CookRole)]
    public class IngredientsController : Controller
    {
        private readonly ICookIngredientsService ingredients;

        public IngredientsController(ICookIngredientsService ingredients)
        {
            this.ingredients = ingredients;
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

            return this.Ok(ingredients);
        }

        public async Task<IActionResult> Create() => this.View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientCreateModel ingredientModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(ingredientModel);
            }

            bool isSuccessfullyCreated = await this.ingredients.Create(ingredientModel.Name, ingredientModel.QuantityInStock, ingredientModel.MinStockQuantityThreshold);

            if (isSuccessfullyCreated)
            {
                this.TempData[SuccessMessageKey] = string.Format(CookConstants.IngredientCreationSuccessMessage, ingredientModel.Name);
            }
            else
            {
                this.ModelState.AddModelError("Name", CookConstants.IngredientExistsErrorMessage);
                return this.View(ingredientModel);
            }

            return this.RedirectToAction(nameof(IngredientsController.Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            IngredientEditModel ingredient = await this.ingredients.GetIngredientToEdit(id);

            if (ingredient == null)
            {
                return this.NotFound();
            }

            return this.View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IngredientEditModel ingredientModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(ingredientModel);
            }

            bool? isSuccessfullyEdited = await this.ingredients.Edit(ingredientModel.Id, ingredientModel.Name, ingredientModel.MinStockQuantityThreshold);

            if (isSuccessfullyEdited == null)
            {
                return this.NotFound();
            }

            if (isSuccessfullyEdited.Value)
            {
                this.TempData[SuccessMessageKey] = string.Format(CookConstants.IngredientEditionSuccessMessage, ingredientModel.Name);
            }
            else
            {
                this.ModelState.AddModelError("Name", CookConstants.IngredientExistsErrorMessage);
                return this.View(ingredientModel);
            }

            return this.RedirectToAction(nameof(IngredientsController.Index));
        }
    }
}
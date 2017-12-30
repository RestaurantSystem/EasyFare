namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using System;
    using System.Linq;
    using static WebConstants;

    [Area(CookRole)]
    [Authorize(Roles = CookRole)]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService ingredients;

        public IngredientsController(IIngredientsService ingredients)
        {
            this.ingredients = ingredients;
        }

        public IActionResult Index(string direction, int page = 1, string search = "")
        {
            if (direction == "forward")
            {
                page++;
            }
            if (direction == "backward" && page > 1)
            {
                page--;
            }

            //int pageUp = (double)itemsCount / (itemsPerPage * Model.Page) > 1 ? Model.Page + 1 : Model.Page;
            //int pageDown = Model.Page > 1 ? Model.Page - 1 : Model.Page;

            //if (search == null)
            //{
            //    search = string.Empty;
            //}

            IngredientsPaginationAndSearchModel ingredients = this.ingredients.GetIngredients(search, page);

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
    }
}
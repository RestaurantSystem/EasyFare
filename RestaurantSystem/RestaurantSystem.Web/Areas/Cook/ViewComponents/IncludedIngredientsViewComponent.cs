﻿namespace RestaurantSystem.Web.Areas.Cook.ViewComponents
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Recipes;

    public class IncludedIngredientsViewComponent : ViewComponent
    {
        private readonly ICookRecipesService recipes;

        public IncludedIngredientsViewComponent(ICookRecipesService recipes)
        {
            this.recipes = recipes;
        }

        public IViewComponentResult Invoke(int? id)
        {
            IEnumerable<RecipeIngredientListModel> ingredients = new List<RecipeIngredientListModel>();

            if (id != null)
            {
                ingredients = this.recipes.GetIngredients(id.Value);
            }

            return this.View(ingredients);
        }
    }
}
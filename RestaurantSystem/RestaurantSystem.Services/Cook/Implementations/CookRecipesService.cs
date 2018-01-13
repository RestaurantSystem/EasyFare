namespace RestaurantSystem.Services.Cook.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Contracts;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using RestaurantSystem.Services.Cook.Models.Recipes;

    public class CookRecipesService : ICookRecipesService
    {
        private readonly RestaurantSystemDbContext db;

        public CookRecipesService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddRecipeIngredient(int recipeId, int productId, int ingreditnId, double quantity)
        {
            if (!this.db.Products.Any(p => p.Id == productId) || !this.db.Ingredients.Any(i => i.Id == ingreditnId))
            {
                return 0;
            }
            else if (recipeId == 0)
            {
                Product product = await this.db.Products.FindAsync(productId);

                Recipe recipe = new Recipe()
                {
                    ProductId = productId
                };

                await this.db.Recipes.AddAsync(recipe);

                await this.db.SaveChangesAsync();

                product.RecipeId = recipe.Id;

                await this.db.RecipeIngredients.AddAsync(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingreditnId,
                    Quantity = quantity
                });

                await this.db.SaveChangesAsync();

                return recipe.Id;
            }
            else
            {
                if (this.db.RecipeIngredients.Any(ri => ri.IngredientId == ingreditnId && ri.RecipeId == recipeId))
                {
                    RecipeIngredient recipeIngredient = await this.db.RecipeIngredients
                        .FindAsync(recipeId, ingreditnId);

                    recipeIngredient.Quantity = quantity;
                }
                else
                {
                    await this.db.RecipeIngredients.AddAsync(new RecipeIngredient
                    {
                        RecipeId = recipeId,
                        IngredientId = ingreditnId,
                        Quantity = quantity
                    });
                }

                await this.db.SaveChangesAsync();

                return recipeId;
            }
        }

        public async Task DeleteIngredients(int recipeId, int[] ingredients)
        {
            if (this.db.Recipes.Any(r => r.Id == recipeId))
            {
                foreach (var ingredient in ingredients)
                {
                    RecipeIngredient recipeIngredient = await this.db.RecipeIngredients.FindAsync(recipeId, ingredient);

                    if (recipeIngredient != null)
                    {
                        this.db.RecipeIngredients.Remove(recipeIngredient);
                    }
                }

                await this.db.SaveChangesAsync();
            }
        }

        public IEnumerable<RecipeIngredientListModel> GetIngredients(int recipeId)
        {
            return this.db.RecipeIngredients
                .Where(r => r.RecipeId == recipeId)
                .ProjectTo<RecipeIngredientListModel>()
                .ToList();
        }

        public async Task<RecipeEditModel> GetRecipeToEdit(int productId)
        {
            Product product = await this.db.Products.FindAsync(productId);

            if (product == null)
            {
                return null;
            }

            RecipeEditModel recipe = new RecipeEditModel()
            {
                RecipeId = product.RecipeId ?? 0,
                ProductId = product.Id,
                ProductName = product.Name,
                Ingredients = await this.db.Ingredients
                    .ProjectTo<IngredientDropDownListModel>()
                    .ToListAsync()
            };

            return recipe;
        }
    }
}
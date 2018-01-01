namespace RestaurantSystem.Services.Cook.Contracts
{
    using RestaurantSystem.Services.Cook.Models.Recipes;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICookRecipesService
    {
        Task<RecipeEditModel> GetRecipeToEdit(int productId);

        IEnumerable<RecipeIngredientListModel> GetIngredients(int recipeId);

        Task<int?> AddRecipeIngredient(int? recipeId, int productId, int ingreditnId, double quantity);

        Task DeleteIngredients(int recipeId, int[] ingredients);
    }
}

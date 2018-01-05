namespace RestaurantSystem.Services.Cook.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Cook.Models.Ingredients;

    public interface ICookIngredientsService
    {
        Task<IngredientsPaginationAndSearchModel> GetIngredients(string search, int page);

        Task<bool> Create(string name, float quantityInStock, float minStockQuantityThreshold);

        Task<IngredientEditModel> GetIngredientToEdit(int ingredientId);

        Task<bool?> Edit(int id, string name, float minStockQuantityThreshold);
    }
}
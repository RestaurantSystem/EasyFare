namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using RestaurantSystem.Services.Manager.Models;

    public interface IManagerIngredientsService
    {
        Task<IngredientsPaginationAndSearchModel> GetIngredients(string search, int page); // Shared?

        Task<IngredientServiceModel> FindByIdAsync(int id);

        Task BuyAsync(int id, int quantity);
    }
}
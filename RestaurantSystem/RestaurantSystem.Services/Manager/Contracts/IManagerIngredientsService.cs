namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;

    public interface IManagerIngredientsService
    {
        Task<bool> AddNewIngredientAsync(string name, float quantity, float minQuantity);
    }
}
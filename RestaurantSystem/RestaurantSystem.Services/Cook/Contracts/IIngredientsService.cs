namespace RestaurantSystem.Services.Cook.Contracts
{
    using RestaurantSystem.Services.Cook.Models.Ingredients;

    public interface IIngredientsService
    {
        IngredientsPaginationAndSearchModel GetIngredients(string search, int page);
    }
}

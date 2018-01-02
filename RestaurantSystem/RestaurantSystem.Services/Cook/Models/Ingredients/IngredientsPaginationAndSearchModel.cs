namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    using System.Collections.Generic;

    public class IngredientsPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<IngredientListModel> Ingredients { get; set; } = new List<IngredientListModel>();
    }
}
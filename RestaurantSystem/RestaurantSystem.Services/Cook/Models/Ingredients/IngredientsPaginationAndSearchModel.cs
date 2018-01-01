using System.Collections.Generic;

namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    public class IngredientsPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<IngredientListModel> Ingredients { get; set; } = new List<IngredientListModel>();
    }
}
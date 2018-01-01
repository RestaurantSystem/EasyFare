namespace RestaurantSystem.Services.Cook.Models.Ingredients
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class IngredientDropDownListModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

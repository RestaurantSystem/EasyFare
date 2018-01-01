namespace RestaurantSystem.Services.Cook.Models.Recipes
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class RecipeIngredientListModel : IMapFrom<RecipeIngredient>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<RecipeIngredient, RecipeIngredientListModel>()
                .ForMember(m => m.Name, cfg => cfg.MapFrom(r => r.Ingredient.Name))
                .ForMember(m => m.Id, cfg => cfg.MapFrom(r => r.IngredientId));
        }
    }
}

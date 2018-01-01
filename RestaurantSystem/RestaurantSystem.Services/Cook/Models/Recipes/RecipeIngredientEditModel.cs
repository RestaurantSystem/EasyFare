namespace RestaurantSystem.Services.Cook.Models.Recipes
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientEditModel : IMapFrom<RecipeIngredient>, IHaveCustomMapping
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<RecipeIngredient, RecipeIngredientEditModel>()
                .ForMember(m => m.IngredientName, cfg => cfg.MapFrom(r => r.Ingredient.Name));
        }
    }
}

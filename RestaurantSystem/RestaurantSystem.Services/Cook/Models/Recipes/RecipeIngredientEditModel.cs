namespace RestaurantSystem.Services.Cook.Models.Recipes
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure;
    using RestaurantSystem.Data.Models;

    public class RecipeIngredientEditModel : IMapFrom<RecipeIngredient>, IHaveCustomMapping
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        [Range(Constants.RecipeIngredientMinQuantity, Constants.RecipeIngredientMaxQuantity)]
        public double Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<RecipeIngredient, RecipeIngredientEditModel>()
                .ForMember(m => m.IngredientName, cfg => cfg.MapFrom(r => r.Ingredient.Name));
        }
    }
}
namespace RestaurantSystem.Services.Cook.Models.Products
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Data.Models;

    public class ProductListModel : IMapFrom<Product>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsCookable { get; set; }

        public ProductType Type { get; set; }

        public bool HasRecipe { get; set; }

        public int OrderTimes { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Product, ProductListModel>()
                .ForMember(m => m.HasRecipe, cfg => cfg.MapFrom(p => p.RecipeId != null))
                .ForMember(m => m.OrderTimes, cfg => cfg.MapFrom(p => p.ProductOrders.Count));
        }
    }
}
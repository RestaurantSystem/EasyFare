namespace RestaurantSystem.Services.Waiter.Models.Products
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class ProductWithQuantityServiceModel : IMapFrom<ProductOrder>, IHaveCustomMapping
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal SinglePrice { get; set; }

        public bool IsOnTable { get; set; }

        public decimal Price => this.SinglePrice * this.Quantity;

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<ProductOrder, ProductWithQuantityServiceModel>()
                .ForMember(m => m.Name, cfg => cfg.MapFrom(po => po.Product.Name))
                .ForMember(m => m.SinglePrice, cfg => cfg.MapFrom(po => po.Product.Price))
                .ForMember(m => m.IsOnTable, cfg => cfg.MapFrom(po => po.IsReadyToServe));
        }
    }
}
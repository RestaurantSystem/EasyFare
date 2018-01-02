using RestaurantSystem.Data.Infrastructure.Enumerations;

namespace RestaurantSystem.Services.Cook.Models.Orders
{
    public class ProductOrderListModel
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public ProductType ProductType { get; set; }
    }
}

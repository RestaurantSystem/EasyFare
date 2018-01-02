namespace RestaurantSystem.Services.Cook.Contracts
{
    using RestaurantSystem.Services.Cook.Models.Orders;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICookOrdersService
    {
        Task<IEnumerable<ProductOrderListModel>> GetOrders();
    }
}

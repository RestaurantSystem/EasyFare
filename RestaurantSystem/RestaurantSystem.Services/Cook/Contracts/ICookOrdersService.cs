namespace RestaurantSystem.Services.Cook.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Cook.Models.Orders;

    public interface ICookOrdersService
    {
        Task<IEnumerable<ProductOrderListModel>> GetOrders();

        Task ConfirmProductReady(int productId, int orderId);
    }
}
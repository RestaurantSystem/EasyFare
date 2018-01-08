namespace RestaurantSystem.Services.Waiter.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Data.Models;

    public interface IWaiterProductsService
    {
        Task<bool> AddToTable(string tableNumber, int productId, string waiterId);

        Task<Product> GetById(int id);

        Task<bool> Remove(string tableNumber, int productId);
    }
}
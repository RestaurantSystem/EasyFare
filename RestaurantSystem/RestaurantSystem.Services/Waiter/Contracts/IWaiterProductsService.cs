namespace RestaurantSystem.Services.Waiter.Contracts
{
    using RestaurantSystem.Data.Models;
    using System.Threading.Tasks;

    public interface IWaiterProductsService
    {
        Task<bool> AddToTable(string tableNumber, int productId, string waiterId);

        Task<Product> GetById(int id);
    }
}
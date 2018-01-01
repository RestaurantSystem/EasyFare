namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Services.Manager.Models;

    public interface IManagerProductsService
    {
        Task<bool> AddNewProductAsync(string name, decimal price, bool isCookable, ProductType type);

        Task<ProductsPaginationAndSearchModel> GetProducts(string search, int page);

        Task<bool> DoesProductExistsAsync(string name);

        Task EditAsync(int id, string name, decimal price, bool isCookable, ProductType type);

        Task<ProductsListModel> FindByIdAsync(int id);
    }
}
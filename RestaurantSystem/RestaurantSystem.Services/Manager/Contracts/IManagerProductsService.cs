namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Data.Infrastructure.Enumerations;

    public interface IManagerProductsService
    {
        Task<bool> BuyNewProductAsync(string name, decimal price, ProductType type);
    }
}
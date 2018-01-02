namespace RestaurantSystem.Services.Cook.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Cook.Models.Products;

    public interface ICookProductsService
    {
        Task<ProductsPaginationAndSearchModel> GetProducts(string search, int page);

        Task<string> GetName(int productId);
    }
}
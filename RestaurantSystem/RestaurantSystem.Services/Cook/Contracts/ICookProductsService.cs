namespace RestaurantSystem.Services.Cook.Contracts
{
    using RestaurantSystem.Services.Cook.Models.Products;
    using System.Threading.Tasks;

    public interface ICookProductsService
    {
        Task<ProductsPaginationAndSearchModel> GetProducts(string search, int page);

        Task<string> GetName(int productId);
    }
}

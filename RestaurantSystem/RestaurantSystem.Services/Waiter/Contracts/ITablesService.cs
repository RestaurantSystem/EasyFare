namespace RestaurantSystem.Services.Waiter.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Waiter.Models.Tables;

    public interface ITablesService
    {
        Task<IEnumerable<TablesListingServiceModel>> AllAsync();
    }
}
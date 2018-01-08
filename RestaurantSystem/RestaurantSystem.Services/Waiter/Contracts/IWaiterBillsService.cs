namespace RestaurantSystem.Services.Waiter.Contracts
{
    using RestaurantSystem.Services.Waiter.Models.Bills;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWaiterBillsService
    {
        Task<IEnumerable<BillsListingServiceModel>> AllAsync(string waiterId);
    }
}
namespace RestaurantSystem.Services.Admin.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Admin.Models;

    public interface IAdminUserService
    {
        Task<IEnumerable<ManagerListingServiceModel>> AllAsync();
    }
}
namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Manager.Models;

    public interface IManagerUserService
    {
        Task<IEnumerable<ManagerListingServiceModel>> AllAsync();
    }
}
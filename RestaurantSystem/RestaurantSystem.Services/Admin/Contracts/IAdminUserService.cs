
namespace RestaurantSystem.Services.Admin.Contracts
{
    using RestaurantSystem.Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminListingServiceModel>> AllAsync();
    }
}

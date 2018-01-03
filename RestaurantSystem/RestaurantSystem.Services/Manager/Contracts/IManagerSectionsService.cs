using RestaurantSystem.Services.Manager.Models;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Manager.Contracts
{
    public interface IManagerSectionsService
    {
        Task<SectionsPaginationAndSearchModel> GetProducts(string search, int page);
    }
}

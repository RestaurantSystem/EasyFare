using RestaurantSystem.Services.Manager.Models;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Manager.Contracts
{
    public interface IManagerSectionsService
    {
        Task<SectionsPaginationAndSearchModel> GetSections(string search, int page);

        Task<bool> AddNewSectionAsync(string name, bool IsForSmokers);
    }
}

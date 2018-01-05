namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Manager.Models;

    public interface IManagerSectionsService
    {
        Task<SectionsPaginationAndSearchModel> GetSections(string search, int page);

        Task<bool> AddNewSectionAsync(string name, bool isForSmokers);
    }
}
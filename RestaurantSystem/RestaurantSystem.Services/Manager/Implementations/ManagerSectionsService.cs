namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;
    using RestaurantSystem.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class ManagerSectionsService : IManagerSectionsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerSectionsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<SectionsPaginationAndSearchModel> GetProducts(string search, int page)
        {
            SectionListModel[] sections = await this.db.Sections
                .ProjectTo<SectionListModel>()
                .OrderBy(i => i.Name)
                .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                sections = sections
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new SectionsPaginationAndSearchModel
            {
                Sections = sections,
                ItemsCount = sections.Count(),
                Search = search,
                Page = page
            };
        }
    }
}

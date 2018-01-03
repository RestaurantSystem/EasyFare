﻿namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;
    using RestaurantSystem.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Models;

    public class ManagerSectionsService : IManagerSectionsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerSectionsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddNewSectionAsync(string name, bool IsForSmokers)
        {
            bool isExist = await this.db.Sections.Select(s => s.Name == name).FirstOrDefaultAsync();

            if (isExist)
            {
                return false;
            }

            Section section = new Section()
            {
                Name = name,
                IsForSmokers = IsForSmokers
            };

            await this.db.Sections.AddAsync(section);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<SectionsPaginationAndSearchModel> GetSections(string search, int page)
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
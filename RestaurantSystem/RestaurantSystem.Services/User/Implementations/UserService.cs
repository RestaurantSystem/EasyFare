namespace RestaurantSystem.Services.User.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Infrastructure;
    using RestaurantSystem.Services.User.Models;

    public class UserService : IUserService
    {
        private readonly RestaurantSystemDbContext db;

        public UserService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<TablesPaginationAndSearchModel> GetTables(string search, int page)
        {
            TablesListModel[] tables = await this.db.Tables
                .ProjectTo<TablesListModel>()
                .OrderBy(i => i.Number)
                .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                tables = tables
                    .Where(i => i.Number.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new TablesPaginationAndSearchModel
            {
                Tables = tables,
                ItemsCount = tables.Count(),
                Search = search,
                Page = page
            };
        }

        public async Task<bool> ReserveTableAsync(string id)
        {
            Table table = await this.db.Tables.FirstOrDefaultAsync(a => a.Number == id);

            if (table == null)
            {
                return false;
            }

            return true;
        }
    }
}

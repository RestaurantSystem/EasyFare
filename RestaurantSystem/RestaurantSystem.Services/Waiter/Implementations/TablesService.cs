namespace RestaurantSystem.Services.Waiter.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Cook.Models.Products;
    using RestaurantSystem.Services.Waiter.Contracts;
    using RestaurantSystem.Services.Waiter.Models.Tables;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TablesService : ITablesService
    {
        private readonly RestaurantSystemDbContext db;

        public TablesService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TablesListingServiceModel>> AllAsync()
        => await this.db.Tables
            .ProjectTo<TablesListingServiceModel>()
            .ToListAsync();

        public async Task<TableOpenedServiceModel> OpenTable(string number, string waiterId)
        {
            var table = await this.db.Tables.SingleOrDefaultAsync(t => t.Number == number);
            if (table == null)
            {
                return null;
            }

            var result = new TableOpenedServiceModel
            {
                Number = number,
                WaiterId = waiterId,
                ListOfAllProducts = await this.db.Products
                .ProjectTo<ProductListModel>()
                .ToListAsync()
            };

            return result;
        }
    }
}
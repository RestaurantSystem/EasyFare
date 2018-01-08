namespace RestaurantSystem.Services.Waiter.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Models.Products;
    using RestaurantSystem.Services.Waiter.Contracts;
    using RestaurantSystem.Services.Waiter.Models.Products;
    using RestaurantSystem.Services.Waiter.Models.Tables;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<TableOpenedServiceModel> OpenTable(string number, string searchWord)
        {
            var table = await this.db.Tables.SingleOrDefaultAsync(t => t.Number == number);
            if (table == null)
            {
                return null;
            }

            var products = await this.db.Products
                .ProjectTo<ProductListModel>()
                .ToListAsync();
            if (!string.IsNullOrEmpty(searchWord))
            {
                products = await this.db.Products
               .Where(p => p.Name.ToLower().Contains(searchWord.ToLower()))
               .ProjectTo<ProductListModel>()
               .ToListAsync();
            }

            var tableOrder = this.db.Orders.SingleOrDefault(o => o.Id == table.OrderId);

            table.Order = tableOrder;
            var result = new TableOpenedServiceModel
            {
                Number = number,
                Products = products,
                SearchWord = searchWord,
            };

            if (tableOrder != null)
            {
                var productsIds = this.db.ProductOrders.Where(po => po.OrderId == table.OrderId)
                    .Select(p => p.ProductId);
                foreach (var id in productsIds)
                {
                    Product product = this.db.Products.FirstOrDefault(p => p.Id == id);
                    if (!table.CurrentProducts.Any(p => p.Name == product.Name))
                    {
                        table.CurrentProducts.Add(product);
                        await this.db.SaveChangesAsync();
                    }

                  
                }
                //var productOrder = this.db.ProductOrders.FirstOrDefault(po => po.OrderId == table.OrderId);
                var productsToList = table.CurrentProducts.Select(p => new ProductWithQuantityServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = this.db.ProductOrders.Where(o=>o.OrderId==table.OrderId&&o.ProductId==p.Id)
                    .FirstOrDefault().Quantity,
                    SinglePrice = p.Price
                }).ToList();

                result.ProductsOnTable = productsToList;

            }

            return result;
        }
    }
}
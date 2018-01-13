namespace RestaurantSystem.Services.Waiter.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Models.Products;
    using RestaurantSystem.Services.Waiter.Contracts;
    using RestaurantSystem.Services.Waiter.Models.Products;
    using RestaurantSystem.Services.Waiter.Models.Tables;

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

        public async Task<TableCheckServiceModel> GetCheck(string tableNumber)
        {
            Table table = await this.db.Tables
                .SingleOrDefaultAsync(t => t.Number == tableNumber);

            var productsIds = this.db.ProductOrders.Where(po => po.OrderId == table.OrderId)
                    .Select(p => p.ProductId);
            foreach (var id in productsIds)
            {
                Product product = this.db.Products.FirstOrDefault(p => p.Id == id);
            }

            var allProductsIds = this.db.Products.Select(a => a.Id);
            var productsToList = new List<ProductWithQuantityServiceModel>();
            foreach (var item in allProductsIds)
            {
                if (productsIds.Any(a => a == item))
                {
                    var product = await this.db.Products.Select(p => new ProductWithQuantityServiceModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Quantity = this.db.ProductOrders.Where(o => o.OrderId == table.OrderId && o.ProductId == p.Id).FirstOrDefault().Quantity,
                        SinglePrice = p.Price
                    }).FirstOrDefaultAsync(a => a.Id == item);

                    productsToList.Add(product);
                }
            }

            var result = new TableCheckServiceModel
            {
                Number = table.Number,
                ProductsOnTable = productsToList
            };

            return result;
        }

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
                }

                await this.db.SaveChangesAsync();
                var productOrder = this.db.ProductOrders.FirstOrDefault(po => po.OrderId == table.OrderId);
                var allProductsIds = this.db.Products.Select(a => a.Id);
                var productsToList = new List<ProductWithQuantityServiceModel>();
                foreach (var item in allProductsIds)
                {
                    if (productsIds.Any(a => a == item))
                    {
                        var product = await this.db.Products.Select(p => new ProductWithQuantityServiceModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Quantity = this.db.ProductOrders.Where(o => o.OrderId == table.OrderId && o.ProductId == p.Id).FirstOrDefault().Quantity,
                            SinglePrice = p.Price
                        }).FirstOrDefaultAsync(a => a.Id == item);

                        productsToList.Add(product);
                    }
                }

                result.ProductsOnTable = productsToList;
            }

            return result;
        }

        public async Task<bool> PrintCheck(string tableNumber)
        {
            if (tableNumber == null)
            {
                return false;
            }
            Table table = await this.db.Tables.SingleOrDefaultAsync(t => t.Number == tableNumber);

            if (table == null)
            {
                return false;
            }

            var orders = this.db.ProductOrders.Where(po => po.OrderId == table.OrderId);

            if (orders == null)
            {
                return false;
            }

            Order order = await this.db.Orders.SingleOrDefaultAsync(o => o.Id == table.OrderId);

            Bill bill = new Bill();

            foreach (var product in orders)
            {
                Product pr = this.db.Products.FirstOrDefault(p => p.Id == product.ProductId);

                bill.Amount += product.Quantity * (pr.Price);
            }

            this.db.Add(bill);

            await this.db.SaveChangesAsync();

            order.BillId = bill.Id;

            this.db.RemoveRange(orders);

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
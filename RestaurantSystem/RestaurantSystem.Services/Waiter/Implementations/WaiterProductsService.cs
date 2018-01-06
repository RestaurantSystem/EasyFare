namespace RestaurantSystem.Services.Waiter.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using System;
    using System.Threading.Tasks;

    public class WaiterProductsService : IWaiterProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public WaiterProductsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddToTable(string tableNumber, int productId, string waiterId)
        {
            var table = await this.db.Tables
                .SingleOrDefaultAsync(t => t.Number == tableNumber);

            if (table == null)
            {
                return false;
            }

            var order = new Order
            {
                WaiterId = waiterId,
                OrderTime = DateTime.Now,
            };

            order.Tables.Add(table);

            var productOrder = new ProductOrder
            {
                ProductId = productId,
                OrderId = order.Id
            };
            table.Order = order;

            var product = await this.db.Products.SingleOrDefaultAsync(p => p.Id == productId);

            order.ProductOrders.Add(productOrder);

            this.db.Orders.Add(order);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await this.db.Products
                .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}
namespace RestaurantSystem.Services.Waiter.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using System;
    using System.Linq;
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
            Product product = await this.db.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if (table.OrderId == null)
            {
                Order order = new Order
                {
                    OrderTime = DateTime.Now,
                    WaiterId = waiterId,
                };

                this.db.Add(order);
                table.OrderId = order.Id;
                await this.db.SaveChangesAsync();

                ProductOrder po = new ProductOrder
                {
                    ProductId = productId,
                    OrderId = order.Id
                };
                if (!this.db.ProductOrders.Any(p => p.OrderId == po.OrderId && p.ProductId == po.ProductId))
                {
                    po.Quantity = 1;
                    this.db.Add(po);
                }
                else
                {
                    po.Quantity++;
                }

                await this.db.SaveChangesAsync();

                order.Tables.Add(table);
                await this.db.SaveChangesAsync();
                return true;
            }
            else
            {
                ProductOrder po = new ProductOrder
                {
                    ProductId = productId,
                    OrderId = (int)table.OrderId
                };
                if (!this.db.ProductOrders.Any(p => p.OrderId == po.OrderId && p.ProductId == po.ProductId))
                {
                    po.Quantity = 1;
                    this.db.Add(po);
                }
                else
                {
                    po.Quantity++;
                }

                await this.db.SaveChangesAsync();
                Order order = await this.db.Orders.SingleOrDefaultAsync(o => o.Id == table.OrderId);

                order.Tables.Add(table);
                await this.db.SaveChangesAsync();
                return true;
            }
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
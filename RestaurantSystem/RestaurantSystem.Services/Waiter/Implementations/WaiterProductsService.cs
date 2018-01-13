namespace RestaurantSystem.Services.Waiter.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;

    public class WaiterProductsService : IWaiterProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public WaiterProductsService(RestaurantSystemDbContext db, UserManager<User> waiters)
        {
            this.db = db;
        }

        public async Task<bool> AddToTable(string tableNumber, int productId, string waiterId)
        {
            var table = await this.db.Tables
                .SingleOrDefaultAsync(t => t.Number == tableNumber);

            var waiter = this.db.Users.SingleOrDefault(u => u.Id == waiterId);

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

                waiter.OrdersAsWaiter.Add(order);

                this.db.Add(order);

                table.OrderId = order.Id;

                await this.db.SaveChangesAsync();

                ProductOrder po = new ProductOrder
                {
                    ProductId = productId,
                    OrderId = order.Id
                };

                await this.db.SaveChangesAsync();

                this.db.Add(po);

                po.Quantity = 1;

                if (!product.IsCookable)
                {
                    po.IsReadyToServe = true;
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

                    if (!product.IsCookable)
                    {
                        po.IsReadyToServe = true;
                    }
                }
                else
                {
                    ProductOrder existing = this.db.ProductOrders.FirstOrDefault(p => p.ProductId == productId &&
                    p.OrderId == table.OrderId);
                    existing.Quantity++;
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

        public async Task<bool> Remove(string tableNumber, int productId)
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
            ProductOrder productOrder = await this.db.ProductOrders
                .SingleOrDefaultAsync(po => po.OrderId == table.OrderId && po.ProductId == productId);

            if (productOrder == null)
            {
                return false;
            }

            if (productOrder.Quantity == 1)
            {
                this.db.ProductOrders.Remove(productOrder);
                await this.db.SaveChangesAsync();
            }
            else
            {
                productOrder.Quantity--;
                if (productOrder.Quantity < 0)
                {
                    productOrder.Quantity = 0;
                }
                await this.db.SaveChangesAsync();
            }

            return true;
        }
    }
}
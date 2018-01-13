namespace RestaurantSystem.Services.Cook.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Orders;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;

    public class CookOrdersService : ICookOrdersService
    {
        private readonly RestaurantSystemDbContext db;

        public CookOrdersService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task ConfirmProductReady(int productId, int orderId)
        {

            ProductOrder productOrder = await this.db.ProductOrders
                .Where(po => po.ProductId == productId && po.OrderId == orderId)
                .SingleOrDefaultAsync();

            if (productOrder != null && !productOrder.IsReadyToServe)
            {
                productOrder.IsReadyToServe = true;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductOrderListModel>> GetOrders()
        {
            return await this.db.ProductOrders
                .Where(p => p.Product.IsCookable && !p.IsReadyToServe)
                .ProjectTo<ProductOrderListModel>()
                .OrderBy(o => o.OrderTime)
                .ToListAsync();
        }
    }
}
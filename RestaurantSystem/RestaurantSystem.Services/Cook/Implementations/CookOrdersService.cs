namespace RestaurantSystem.Services.Cook.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Orders;
    using RestaurantSystem.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CookOrdersService : ICookOrdersService
    {
        private readonly RestaurantSystemDbContext db;

        public CookOrdersService(RestaurantSystemDbContext db)
        {
            this.db = db;
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

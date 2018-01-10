namespace RestaurantSystem.Services.Waiter.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using RestaurantSystem.Services.Waiter.Models.Bills;

    public class WaiterBillsService : IWaiterBillsService
    {
        private readonly RestaurantSystemDbContext db;

        public WaiterBillsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BillsListingServiceModel>> AllAsync(string waiterId)
        {
            var orders = await db.Orders.Where(o => o.WaiterId == waiterId && o.OrderTime.Date == DateTime.Today)
                 .ToListAsync();

            var bills = new List<Bill>();

            foreach (var order in orders.Where(a => a.BillId != null))
            {
                Bill bill = this.db.Bills.FirstOrDefault(b => b.Id == order.BillId);
                var ammount = order.ProductOrders.Sum(p => p.Product.Price);

                bills.Add(bill);
            }

            var result = new List<BillsListingServiceModel>();

            foreach (var bill in bills)
            {
                BillsListingServiceModel model = new BillsListingServiceModel
                {
                    Id = bill.Id,
                    Amount = bill.Amount
                };

                result.Add(model);
            }

            return result;
        }
    }
}
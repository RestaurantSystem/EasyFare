namespace RestaurantSystem.Web.Areas.Waiter.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Waiter.Contracts;
    using static WebConstants;

    [Area(WaiterRole)]
    [Authorize(Roles = WaiterArea)]
    public class BillsController : Controller
    {
        private readonly IWaiterBillsService bills;
        private readonly UserManager<User> waiters;

        public BillsController(IWaiterBillsService bills,
            UserManager<User> waiters)
        {
            this.bills = bills;
            this.waiters = waiters;
        }

        public async Task<IActionResult> MyBills()
        {
            string waiterId = this.waiters.GetUserId(User);

            var result = await this.bills.AllAsync(waiterId);

            return this.View(result);
        }
    }
}
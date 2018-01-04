namespace RestaurantSystem.Services.Waiter.Implementations
{
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Waiter.Contracts;

    public class WaiterProductsService : IWaiterProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public WaiterProductsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }
    }
}
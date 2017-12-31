namespace RestaurantSystem.Services.Manager.Implementations
{
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Manager.Contracts;

    public class ManagerIngredientsService : IManagerIngredientsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerIngredientsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }
    }
}
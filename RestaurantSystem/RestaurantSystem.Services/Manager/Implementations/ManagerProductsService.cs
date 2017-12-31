namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Manager.Contracts;

    public class ManagerProductsService : IManagerProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerProductsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> BuyNewProductAsync(string name, decimal price, ProductType type)
        {
            Product exists = await this.db.Products.FirstOrDefaultAsync(n => n.Name == name);

            if (exists != null)
            {
                return false;
            }

            Product product = new Product()
            {
                Name = name,
                Price = price,
                Type = type
            };

            await this.db.Products.AddAsync(product);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
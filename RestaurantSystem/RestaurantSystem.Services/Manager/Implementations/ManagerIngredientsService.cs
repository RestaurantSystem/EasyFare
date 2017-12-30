namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Manager.Contracts;

    public class ManagerIngredientsService : IManagerIngredientsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerIngredientsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddNewIngredientAsync(string name, float quantity, float minQuantity)
        {
            Ingredient found = await this.db.Ingredients.FirstOrDefaultAsync(n => n.Name == name);

            if (found != null)
            {
                return true;
            }

            Ingredient ingredient = new Ingredient()
            {
                Name = name,
                QuantityInStock = quantity,
                MinStockQuantityTreshold = minQuantity
            };

            await this.db.Ingredients.AddAsync(ingredient);
            await this.db.SaveChangesAsync();

            return false;
        }
    }
}
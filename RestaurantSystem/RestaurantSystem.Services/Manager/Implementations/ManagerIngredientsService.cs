namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Cook.Models.Ingredients;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;

    public class ManagerIngredientsService : IManagerIngredientsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerIngredientsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IngredientsPaginationAndSearchModel> GetIngredients(string search, int page)
        {
            IngredientListModel[] ingredients = await this.db.Ingredients
                .Where(i => i.MinStockQuantityTreshold >= i.QuantityInStock)
                .ProjectTo<IngredientListModel>()
                .OrderBy(i => i.Name)
                .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                ingredients = ingredients
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new IngredientsPaginationAndSearchModel
            {
                Ingredients = ingredients,
                ItemsCount = ingredients.Count(),
                Search = search,
                Page = page
            };
        }

        public async Task<IngredientServiceModel> FindByIdAsync(int id)
        {
            var result = await this.db.Ingredients
               .Where(c => c.Id == id)
               .ProjectTo<IngredientServiceModel>()
               .FirstOrDefaultAsync();

            return result;
        }

        public async Task BuyAsync(int id, int quantity)
        {
            var ingredient = await this.db.Ingredients.FirstOrDefaultAsync(c => c.Id == id);

            ingredient.QuantityInStock += quantity;

            await this.db.SaveChangesAsync();
        }
    }
}
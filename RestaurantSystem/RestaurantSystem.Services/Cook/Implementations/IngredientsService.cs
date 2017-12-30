namespace RestaurantSystem.Services.Cook.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Models.Ingredients;
    using RestaurantSystem.Data;
    using System.Linq;

    public class IngredientsService : IIngredientsService
    {
        private readonly RestaurantSystemDbContext db;

        public IngredientsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public IngredientsPaginationAndSearchModel GetIngredients(string search, int page)
        {
            IngredientListModel[] ingredients = this.db.Ingredients
                .ProjectTo<IngredientListModel>()
                .ToArray();

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
    }
}

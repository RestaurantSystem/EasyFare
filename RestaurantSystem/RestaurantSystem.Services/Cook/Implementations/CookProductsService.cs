namespace RestaurantSystem.Services.Cook.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Products;
    using RestaurantSystem.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class CookProductsService : ICookProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public CookProductsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<string> GetName(int productId)
        {
            return await this.db.Products
                .Where(p => p.Id == productId)
                .Select(p => p.Name)
                .SingleOrDefaultAsync();
        }

        public async Task<ProductsPaginationAndSearchModel> GetProducts(string search, int page)
        {
            ProductListModel[] products = await this.db.Products
                 .ProjectTo<ProductListModel>()
                 .OrderBy(i => i.Name)
                 .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                products = products
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new ProductsPaginationAndSearchModel
            {
                Products = products,
                ItemsCount = products.Count(),
                Search = search,
                Page = page
            };
        }
    }
}

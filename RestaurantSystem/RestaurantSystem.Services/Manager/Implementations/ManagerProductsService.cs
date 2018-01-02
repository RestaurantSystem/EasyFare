namespace RestaurantSystem.Services.Manager.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;

    public class ManagerProductsService : IManagerProductsService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerProductsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddNewProductAsync(string name, decimal price, bool isCookable, ProductType type)
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
                IsCookable = isCookable,
                Type = type
            };

            await this.db.Products.AddAsync(product);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<ProductsPaginationAndSearchModel> GetProducts(string search, int page)
        {
            ProductsListModel[] products = await this.db.Products
                .ProjectTo<ProductsListModel>()
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

        public async Task<bool> EditAsync(int id, string name, decimal price, bool isCookable, ProductType type, bool sameName)
        {
            Product product = await this.db.Products.FindAsync(id);

            if (!sameName)
            {
                Product exists = await this.db.Products.FirstOrDefaultAsync(a => a.Name == name);
                if (exists == null)
                {
                    product.Name = name;
                }
                else
                {
                    return false;
                }
            }

            product.Price = price;
            product.IsCookable = isCookable;
            product.Type = type;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<ProductsListModel> FindByIdAsync(int id)
        {
            var result = await this.db.Products
               .Where(c => c.Id == id)
               .ProjectTo<ProductsListModel>()
               .FirstOrDefaultAsync();

            return result;
        }
    }
}
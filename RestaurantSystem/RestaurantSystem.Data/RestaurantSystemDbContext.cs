namespace RestaurantSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Configuration;
    using RestaurantSystem.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class RestaurantSystemDbContext : IdentityDbContext<User>
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<WaiterSection> WaiterSections { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public Task First { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }

        public RestaurantSystemDbContext(DbContextOptions<RestaurantSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IngredientConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new SectionConfiguration());

            builder.ApplyConfiguration(new WaiterSectionConfiguration());

            builder.ApplyConfiguration(new TableConfiguration());

            builder.ApplyConfiguration(new ProductOrderConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new RecipeIngredientConfiguration());

            builder.ApplyConfiguration(new TableProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
namespace RestaurantSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Models;

    public class RestaurantSystemDbContext : IdentityDbContext<User>
    {
        public RestaurantSystemDbContext(DbContextOptions<RestaurantSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
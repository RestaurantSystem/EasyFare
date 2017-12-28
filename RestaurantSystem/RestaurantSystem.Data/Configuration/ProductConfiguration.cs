namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasAlternateKey(e => e.Name);

            builder.HasOne(e => e.Recipe).WithOne(r => r.Product).HasForeignKey<Product>(p => p.RecipeId);
        }
    }
}

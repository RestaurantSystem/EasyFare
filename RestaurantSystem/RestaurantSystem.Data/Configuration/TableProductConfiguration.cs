namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class TableProductConfiguration : IEntityTypeConfiguration<TableProduct>
    {
        public void Configure(EntityTypeBuilder<TableProduct> builder)
        {
            builder.HasKey(e => new { e.TableNumber, e.ProductId });

            builder.HasOne(e => e.Product).WithMany(p => p.Tables).HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Table).WithMany(o => o.Products).HasForeignKey(e => e.TableNumber);
        }
    }
}
namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(e => new { e.ProductId, e.OrderId });

            builder.HasOne(e => e.Product).WithMany(p => p.ProductOrders).HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Order).WithMany(o => o.ProductOrders).HasForeignKey(e => e.OrderId);
        }
    }
}

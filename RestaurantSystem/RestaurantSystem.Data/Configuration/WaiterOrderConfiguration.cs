namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class WaiterOrderConfiguration : IEntityTypeConfiguration<WaiterOrder>
    {
        public void Configure(EntityTypeBuilder<WaiterOrder> builder)
        {
            builder.HasKey(e => new { e.WaiterId, e.OrderId });

            builder.HasOne(e => e.Waiter).WithMany(w => w.WaiterOrders).HasForeignKey(e => e.WaiterId);

            builder.HasOne(e => e.Order).WithMany(w => w.WaiterOrders).HasForeignKey(e => e.OrderId);
        }
    }
}

namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(e => e.Bill).WithMany(b => b.Orders).HasForeignKey(e => e.BillId);

            builder.HasOne(e => e.Waiter).WithMany(w => w.OrdersAsWaiter).HasForeignKey(e => e.WaiterId);
        }
    }
}
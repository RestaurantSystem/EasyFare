namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(e => e.Number);

            builder.HasOne(e => e.Section).WithMany(s => s.Tables).HasForeignKey(e => e.SectionId);

            builder.HasOne(e => e.Order).WithMany(o => o.Tables).HasForeignKey(e => e.OrderId);

            builder.HasMany(e => e.Reservations).WithOne(r => r.Table).HasForeignKey(r => r.TableNumber);
        }
    }
}

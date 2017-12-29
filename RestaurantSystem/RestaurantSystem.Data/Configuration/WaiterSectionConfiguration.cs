namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class WaiterSectionConfiguration : IEntityTypeConfiguration<WaiterSection>
    {
        public void Configure(EntityTypeBuilder<WaiterSection> builder)
        {
            builder.HasKey(e => new { e.WaiterId, e.SectionId });

            builder.HasOne(e => e.Waiter).WithMany(w => w.WaiterSections).HasForeignKey(e => e.WaiterId);

            builder.HasOne(e => e.Section).WithMany(s => s.WaiterSections).HasForeignKey(e => e.SectionId);
        }
    }
}
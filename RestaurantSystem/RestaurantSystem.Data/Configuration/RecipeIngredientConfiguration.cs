namespace RestaurantSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RestaurantSystem.Data.Models;

    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(e => new { e.RecipeId, e.IngredientId });

            builder.HasOne(e => e.Ingredient).WithMany(i => i.RecipeIngredients).HasForeignKey(e => e.IngredientId);

            builder.HasOne(e => e.Recipe).WithMany(r => r.RecipeIngredients).HasForeignKey(e => e.RecipeId);
        }
    }
}
namespace RestaurantSystem.Data.Infrastructure
{
    public class Constants
    {
        // Ingredient
        public const string IngredientNameLenghtErrorMessage = "Name should be between 3 and 150 symbols long.";

        public const int IngredientNameMinLength = 3;

        public const int IngredientNameMaxLength = 150;

        public const int IngredientMinQuantityInStock = 0;

        public const int IngredientMaxQuantityInStock = 100000;

        public const int IngredientMinStockQuantityThreshold = 0;

        public const int IngredientMaxStockQuantityThreshold = 100000;

        // Product
        public const string ProductNameLengthErrorMessage = "Name should be between 3 and 150 symbols long.";

        public const int ProductNameMinLength = 3;

        public const int ProductNameMaxLength = 150;

        public const int ProductMinPrice = 0;

        public const int ProductMaxPrice = 100000;

        // Section
        public const string SectionNameLengthErrorMessage = "Name should be between 1 and 50 symbols long.";

        public const int SectionNameMinLength = 1;

        public const int SectionNameMaxLength = 50;

        // Table
        public const int TableMaxSeats = 12;

        public const int TableMinSeats = 2;

        public const int TableMaxNumberLength = 3;

        public const int TableMinNumberLength = 1;

        public const string TableNuberLengthErrorMessage = "Table number should be between 1 and 3 symbols long.";

        // Waiter
        public const string WaiterNameLengthErrorMessage = "Name should be between 3 and 200 symbols long.";

        public const int WaiterNameMinLength = 3;

        public const int WaiterNameMaxLength = 200;

        // RecipeIngredient
        public const double RecipeIngredientMinQuantity = 0.01;

        public const int RecipeIngredientMaxQuantity = 1000;

        // User
        public const int UserMinSalary = 0;

        public const int UserMaxSalary = 5000000;

        public const int UserMinMoney = 0;
    }
}
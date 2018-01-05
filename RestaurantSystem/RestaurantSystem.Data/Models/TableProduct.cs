namespace RestaurantSystem.Data.Models
{
    public class TableProduct
    {
        public string TableNumber { get; set; }

        public Table Table { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
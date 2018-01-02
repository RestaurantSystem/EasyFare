namespace RestaurantSystem.Data.Models
{
    public class WaiterOrder
    {
        public string WaiterId { get; set; }

        public User Waiter { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}

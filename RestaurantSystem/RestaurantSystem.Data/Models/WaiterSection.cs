namespace RestaurantSystem.Data.Models
{
    public class WaiterSection
    {
        public string WaiterId { get; set; }

        public User Waiter { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}
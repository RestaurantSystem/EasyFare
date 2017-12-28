namespace RestaurantSystem.Data.Models
{
    public class WaiterSection
    {
        public int WaiterId { get; set; }

        public Waiter Waiter { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }
    }
}

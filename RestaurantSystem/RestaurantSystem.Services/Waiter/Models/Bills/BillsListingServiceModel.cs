namespace RestaurantSystem.Services.Waiter.Models.Bills
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class BillsListingServiceModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
    }
}
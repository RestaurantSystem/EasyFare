namespace RestaurantSystem.Services.Admin.Models
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class AdminListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
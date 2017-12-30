namespace RestaurantSystem.Web.Areas.Manager.Models.Users
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RestaurantSystem.Services.Manager.Models;

    public class ManagerUsersViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<ManagerListingServiceModel> Users { get; set; }
    }
}
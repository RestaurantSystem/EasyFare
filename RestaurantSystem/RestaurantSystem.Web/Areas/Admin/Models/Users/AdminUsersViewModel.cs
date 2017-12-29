namespace RestaurantSystem.Web.Areas.Admin.Models.Users
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RestaurantSystem.Services.Admin.Models;

    public class AdminUsersViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<AdminListingServiceModel> Users { get; set; }
    }
}

namespace RestaurantSystem.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RestaurantSystem.Services.Admin.Models;
    using System.Collections.Generic;

    public class AdminUsersViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<AdminListingServiceModel> Users { get; set; }
    }
}

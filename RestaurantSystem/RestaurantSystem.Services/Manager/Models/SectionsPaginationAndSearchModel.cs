namespace RestaurantSystem.Services.Manager.Models
{
    using System.Collections.Generic;
    using RestaurantSystem.Services.Cook.Models;

    public class SectionsPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<SectionListModel> Sections { get; set; } = new List<SectionListModel>();
    }
}

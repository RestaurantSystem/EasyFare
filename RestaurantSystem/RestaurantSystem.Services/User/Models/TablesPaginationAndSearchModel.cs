namespace RestaurantSystem.Services.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RestaurantSystem.Services.Cook.Models;

    public class TablesPaginationAndSearchModel : PaginationAndSearchModel
    {
        public IEnumerable<TablesListModel> Tables { get; set; } = new List<TablesListModel>();
    }
}

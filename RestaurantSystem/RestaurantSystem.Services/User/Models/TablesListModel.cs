namespace RestaurantSystem.Services.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class TablesListModel : IMapFrom<Table>
    {
        public string Number { get; set; }
        
        public int Seats { get; set; }
    }
}

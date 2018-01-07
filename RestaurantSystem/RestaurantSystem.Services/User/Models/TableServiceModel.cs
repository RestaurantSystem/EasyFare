namespace RestaurantSystem.Services.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TableServiceModel
    {
        public string Number { get; set; }
        
        public int Seats { get; set; }

        public DateTime Date { get; set; }
    }
}

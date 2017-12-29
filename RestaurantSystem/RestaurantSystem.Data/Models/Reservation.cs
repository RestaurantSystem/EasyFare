namespace RestaurantSystem.Data.Models
{
    using System;

    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public string TableNumber { get; set; }

        public Table Table { get; set; }
    }
}
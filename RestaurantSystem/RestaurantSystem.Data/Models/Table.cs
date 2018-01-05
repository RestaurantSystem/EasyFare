﻿namespace RestaurantSystem.Data.Models
{
    using Infrastructure;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Table
    {
        [Required]
        [StringLength(Constants.TableMaxNumberLength, ErrorMessage = Constants.TableNuberLengthErrorMessage, MinimumLength = Constants.TableMinNumberLength)]
        public string Number { get; set; }

        [Required]
        [Range(Constants.TableMinSeats, Constants.TableMaxSeats)]
        public int Seats { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public ICollection<TableProduct> Products { get; set; } = new List<TableProduct>();

        public ICollection<Product> ProductsOnTable { get; set; } = new List<Product>();
    }
}
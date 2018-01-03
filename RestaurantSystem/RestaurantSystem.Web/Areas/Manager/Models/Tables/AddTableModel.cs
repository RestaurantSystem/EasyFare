namespace RestaurantSystem.Web.Areas.Manager.Models.Tables
{
    using RestaurantSystem.Data.Infrastructure;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddTableModel
    {
        [Required]
        [StringLength(Constants.TableMaxNumberLength, ErrorMessage = Constants.TableNuberLengthErrorMessage, MinimumLength = Constants.TableMinNumberLength)]
        public string Number { get; set; }

        [Range(Constants.TableMinSeats, Constants.TableMaxSeats)]
        public int Seats { get; set; }

        public int SectionId { get; set; }
    }
}

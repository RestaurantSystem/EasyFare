namespace RestaurantSystem.Web.Areas.Manager.Models.Tables
{
    using System.ComponentModel.DataAnnotations;
    using RestaurantSystem.Data.Infrastructure;

    public class AddTableModel
    {
        [Required]
        [StringLength(Constants.TableMaxNumberLength, ErrorMessage = Constants.TableNuberLengthErrorMessage, MinimumLength = Constants.TableMinNumberLength)]
        public string Number { get; set; }

        [Required]
        [Range(Constants.TableMinSeats, Constants.TableMaxSeats)]
        public int Seats { get; set; }

        public int SectionId { get; set; }
    }
}
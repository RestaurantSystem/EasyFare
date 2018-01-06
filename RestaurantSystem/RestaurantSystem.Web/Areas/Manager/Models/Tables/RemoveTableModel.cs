namespace RestaurantSystem.Web.Areas.Manager.Models.Tables
{
    using RestaurantSystem.Data.Infrastructure;
    using System.ComponentModel.DataAnnotations;

    public class RemoveTableModel
    {
        [Required]
        [StringLength(Constants.TableMaxNumberLength, ErrorMessage = Constants.TableNuberLengthErrorMessage, MinimumLength = Constants.TableMinNumberLength)]
        public string Number { get; set; }

        public int SectionId { get; set; }
    }
}
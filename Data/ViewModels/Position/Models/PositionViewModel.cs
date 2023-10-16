using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Position.Models
{
    public class PositionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dates are required!")]
        public string Dates { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public int WorkId { get; set; }
    }
}
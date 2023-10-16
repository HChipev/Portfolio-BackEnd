using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Education.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Institution is required!")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Degree is required!")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Dates are required!")]
        public string Dates { get; set; }
    }
}
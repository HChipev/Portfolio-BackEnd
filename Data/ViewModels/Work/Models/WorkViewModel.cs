using System.ComponentModel.DataAnnotations;
using Data.ViewModels.Position.Models;

namespace Data.ViewModels.Work.Models
{
    public class WorkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company is required!")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Site URL is required!")]
        public string SiteUrl { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Positions are required!")]
        [MinLength(1, ErrorMessage = "At least one position is required.")]
        public IEnumerable<PositionViewModel> Positions { get; set; } = new List<PositionViewModel>();
    }
}
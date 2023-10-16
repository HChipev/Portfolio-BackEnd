using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Framework.Models
{
    public class FrameworkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
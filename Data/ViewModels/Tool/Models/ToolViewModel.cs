using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Tool.Models
{
    public class ToolViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
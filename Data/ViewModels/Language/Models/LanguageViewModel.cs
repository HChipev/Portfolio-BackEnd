using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Language.Models
{
    public class LanguageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
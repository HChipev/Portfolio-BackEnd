using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Educations")]
    public class Education : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Institution is required!")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Degree is required!")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Dates are required!")]
        public string Dates { get; set; }
    }
}
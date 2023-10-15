using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Positions")]
    public class Position : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dates is required!")]
        public string Dates { get; set; }

        [Required(ErrorMessage = "Work Id is required!")]
        public int WorkId { get; set; }

        public Work Work { get; set; }
    }
}
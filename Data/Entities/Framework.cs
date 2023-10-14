using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Frameworks")]
    public class Framework : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
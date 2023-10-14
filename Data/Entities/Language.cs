using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Languages")]
    public class Language : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Language is required!")]
        public string Name { get; set; }
    }
}
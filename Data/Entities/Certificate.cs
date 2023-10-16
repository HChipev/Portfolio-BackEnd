using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Certificates")]
    public class Certificate : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Issuer is required!")]
        public string Issuer { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public byte[] Image { get; set; }
    }
}
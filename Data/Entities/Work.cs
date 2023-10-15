using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Works")]
    public class Work : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company is required!")]
        [MaxLength(50, ErrorMessage = "Company cannot be longer than 50 characters!")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Position is required!")]
        public ICollection<Position> Positions { get; set; }

        [Required(ErrorMessage = "SiteUrl is required!")]
        public string siteUrl { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstract;

namespace Data.Entities
{
    [Table("Portfolios")]
    public class Portfolio : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Site URL is required!")]
        public string SiteUrl { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Certificate.Models
{
    public class CertificateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Issuer is required!")]
        public string Issuer { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public byte[] Image { get; set; }
    }
}
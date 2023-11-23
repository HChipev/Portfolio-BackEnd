using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels.Communication.Models
{
    public class CommunicationViewModel
    {
        [Required]
        public string SenderEmail { get; set; }

        [Required]
        public string SenderName { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
using Data.ViewModels.Position.Models;

namespace Data.ViewModels.Work.Models
{
    public class WorkViewModel
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string SiteUrl { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public IEnumerable<PositionViewModel> Positions { get; set; } = new List<PositionViewModel>();
    }
}
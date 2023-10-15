using Common;
using Data.ViewModels.Tool.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IToolService : IService
    {
        public ServiceResult<bool> AddTool(ToolViewModel tool);

        public ServiceResult<bool> DeleteTool(int id);

        public ServiceResult<bool> UpdateTool(ToolViewModel tool);

        public ServiceResult<ToolViewModel> GetTool(int id);

        public ServiceResult<IEnumerable<ToolViewModel>> GetTools();
    }
}
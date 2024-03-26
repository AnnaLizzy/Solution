using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebApplicationAPI.DTOs;


namespace WebApplicationAPI.Service.Interfaces
{
    public interface IWorkShiftService
    {
        Task<List<WorkShiftDTO>> GetWorkShifts();
        Task<WorkShiftDTO> GetWorkShiftByID(int id);
        Task CreateWorkShift(WorkShiftDTO workShift);
        Task UpdateWorkShift(WorkShiftDTO workShift);
        Task DeleteWorkShift(int id);
    }
}

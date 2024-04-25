using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IWorkScheduleService
    {
        Task<List<WorkScheduleDTO>> GetWorkSchedules();
        Task<WorkScheduleDTO> GetWorkSchedule(int id);
        Task<WorkScheduleDTO> GetWorkScheduleByEmployeeId(int id);
        Task<List<WorkScheduleDTO>> GetWorkScheduleByLocationId(string id);
        Task<ApiResult<bool>> CreateWorkSchedule( WorkScheduleDTO model);
        Task UpdateWorkSchedule(int id, WorkScheduleDTO model);
        Task DeleteWorkSchedule(int id);
    }
}

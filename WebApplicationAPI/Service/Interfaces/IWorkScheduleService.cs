using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IWorkScheduleService
    {
        Task<List<WorkScheduleDTO>> GetWorkSchedules();
        Task<WorkScheduleDTO> GetWorkSchedule(int id);
        Task CreateWorkSchedule( WorkScheduleDTO model);
        Task UpdateWorkSchedule(int id, WorkScheduleDTO model);
        Task DeleteWorkSchedule(int id);
    }
}

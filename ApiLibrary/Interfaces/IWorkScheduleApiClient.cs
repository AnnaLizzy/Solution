using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IWorkScheduleApiClient
    {
        Task<List<WorkScheduleViewModel>> GetWorkSchedules();
        Task<WorkScheduleViewModel> GetWorkSchedule(int? id);
        Task<List<OndutyListLocationViewModel>> GetOndutyListLocationsByAreaID(int? id);
        Task<bool> CreateWorkSchedule(CreateWorkScheduleViewModel workSchedule);
        Task<bool> UpdateWorkSchedule(WorkScheduleViewModel workSchedule);
        Task<bool> DeleteWorkSchedule(int? id);
    }
}

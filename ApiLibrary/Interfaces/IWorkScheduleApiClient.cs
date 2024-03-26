using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
    public interface IWorkScheduleApiClient
    {
        Task<List<WorkScheduleViewModel>> GetWorkSchedules();
        Task<WorkScheduleViewModel> GetWorkSchedule(int? id);
        Task<bool> CreateWorkSchedule(CreateWorkScheduleViewModel workSchedule);
        Task<bool> UpdateWorkSchedule(WorkScheduleViewModel workSchedule);
        Task<bool> DeleteWorkSchedule(int? id);
    }
}

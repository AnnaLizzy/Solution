using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
    public interface IWorkShiftApiClient
    {
        Task<List<WorkShiftViewModel>> GetWorkShifts();
        Task<WorkShiftViewModel> GetWorkShift(int id);
        Task<bool> AddWorkShift(WorkShiftViewModel workShift);
        Task<bool> UpdateWorkShift(WorkShiftViewModel workShift);
        Task<bool> DeleteWorkShift(int id);
    }
}

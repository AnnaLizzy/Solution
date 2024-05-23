using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// work schedule service
    /// </summary>
    public interface IWorkScheduleService
    {
        /// <summary>
        /// get all work schedule
        /// </summary>
        /// <returns></returns>
        Task<List<WorkScheduleDTO>> GetWorkSchedules();
        /// <summary>
        /// get work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WorkScheduleDTO> GetWorkSchedule(int id);
        /// <summary>
        /// get work schedule by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WorkScheduleDTO> GetWorkScheduleByEmployeeId(int id);
        /// <summary>
        /// get work schedule by location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<WorkScheduleDTO>> GetWorkScheduleByLocationId(string id);
        /// <summary>
        /// create work schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApiResult<bool>> CreateWorkSchedule( WorkScheduleDTO model);
        /// <summary>
        /// update work schedule
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateWorkSchedule(int id, WorkScheduleDTO model);
        /// <summary>
        /// delete work schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteWorkSchedule(int id);
    }
}

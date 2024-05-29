namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// WorkShift 
    /// </summary>
    public interface IWorkShiftService
    {
        /// <summary>
        /// get all work shift
        /// </summary>
        /// <returns></returns>
        Task<List<WorkShiftDTO>> GetWorkShifts();
        /// <summary>
        /// get work shift by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WorkShiftDTO> GetWorkShiftByID(int id);
        /// <summary>
        /// create work shift
        /// </summary>
        /// <param name="workShift"></param>
        /// <returns></returns>
        Task CreateWorkShift(WorkShiftDTO workShift);
        /// <summary>
        /// update work shift
        /// </summary>
        /// <param name="workShift"></param>
        /// <returns></returns>
        Task UpdateWorkShift(WorkShiftDTO workShift);
        /// <summary>
        /// delete work shift
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteWorkShift(int id);
    }
}

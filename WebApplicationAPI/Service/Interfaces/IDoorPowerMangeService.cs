using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDoorPowerMangeService
    {
        /// <summary>
        /// Get all user sign
        /// </summary>
        /// <returns></returns>
        Task<List<DoorPowerManageDTO>> GetDoorPowerManager();
        /// <summary>
        /// get user sign by bgid
        /// </summary>
        /// <param name="bgId"></param>
        /// <returns></returns>
        Task<List<DoorPowerManageDTO>> GetDoorPowerManager(int bgId);
        /// <summary>
        /// get user sign by employee No
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        //Task<DoorPowerManageDTO> GetDoorPowerManagerByEmp(string empNo);
        
    }
}

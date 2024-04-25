using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IDoorPowerMangeService
    {
        Task<List<DoorPowerManageDTO>> GetDoorPowerManager();
        Task<List<DoorPowerManageDTO>> GetDoorPowerManager(int bgId);
        
    }
}

using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IRegionService
    {
        Task<List<RegionDTO>> GetRegions();
        Task<List<RegionDTO>> GetRegion(int id);
    }
}

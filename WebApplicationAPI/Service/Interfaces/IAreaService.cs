using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IAreaService
    {
        Task<List<AreaDTO>> GetAreas();
        Task<AreaDTO> GetArea(int id);
    }
}

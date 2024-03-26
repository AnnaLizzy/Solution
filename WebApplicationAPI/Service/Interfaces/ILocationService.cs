using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationDTO>> GetLocations();
        Task<LocationDTO> GetLocation(int id);
        Task CreateLocation(LocationDTO locationDTO);
        Task UpdateLocation(int id, LocationDTO locationDTO);
        Task DeleteLocation(int id);
    }
}

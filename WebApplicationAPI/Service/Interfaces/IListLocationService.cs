using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IListLocationService
    {
        Task<List<ListLocationDTO>> GetLocations();
        Task<List<ListLocationDTO>> GetLocationByAreaID(int id);
        Task<ListLocationDTO> CreateLocation(ListLocationDTO listlocationDTO);
        Task UpdateLocation(int id, ListLocationDTO listlocationDTO);
        Task DeleteLocation(int id);
    }
}

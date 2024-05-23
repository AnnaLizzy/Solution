using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// List location service
    /// </summary>
    public interface IListLocationService
    {
        /// <summary>
        /// get location
        /// </summary>
        /// <returns></returns>
        Task<List<ListLocationDTO>> GetLocations();
        /// <summary>
        /// get location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ListLocationDTO>> GetLocationByAreaID(int id);
        /// <summary>
        /// create location
        /// </summary>
        /// <param name="listlocationDTO"></param>
        /// <returns></returns>
        Task<ListLocationDTO> CreateLocation(ListLocationDTO listlocationDTO);
        /// <summary>
        /// update location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listlocationDTO"></param>
        /// <returns></returns>
        Task UpdateLocation(int id, ListLocationDTO listlocationDTO);
        /// <summary>
        /// delete location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteLocation(int id);
    }
}

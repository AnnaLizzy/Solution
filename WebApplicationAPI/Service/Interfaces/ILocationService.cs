using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// Interface for LocationService
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Get all locations
        /// </summary>
        /// <returns></returns>
        Task<List<LocationDTO>> GetLocations();
        /// <summary>
        /// get location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LocationDTO> GetLocation(int id);
        /// <summary>
        /// Create location
        /// </summary>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        Task<int> CreateLocation(LocationDTO locationDTO);
        /// <summary>
        /// update location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        Task<bool> UpdateLocation(int id, LocationDTO locationDTO);
        /// <summary>
        /// delete location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteLocation(int id);
    }
}

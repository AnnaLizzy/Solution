using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// Get area 
    /// </summary>
    public interface IAreaService
    {
        /// <summary>
        /// get all area
        /// </summary>
        /// <returns></returns>
        Task<List<AreaDTO>> GetAreas();
        /// <summary>
        /// get area by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AreaDTO> GetArea(long id);
    }
}

namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// region
    /// </summary>
    public interface IRegionService
    {
        /// <summary>
        /// get all region
        /// </summary>
        /// <returns></returns>
        Task<List<RegionDTO>> GetRegions();
        /// <summary>
        /// get all region by area id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<RegionDTO>> GetRegion(int id);
        /// <summary>
        /// get by region ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RegionDTO> GetRegionByID(int id);
    }
}

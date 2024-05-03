using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// region
    /// </summary>
    /// <param name="context2"></param>
    public class RegionService(AppDbContext2 context2) : IRegionService
    {
        private readonly AppDbContext2 _context2 = context2;
        /// <summary>
        /// Get region by area id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<List<RegionDTO>> GetRegion(int id)
        {
            var areaId = await _context2.Area.FindAsync(id) ?? throw new AppException(SystemConstants.MessageError.AreaError + id);
            var query = from region in _context2.Region
                        join areaRegion in _context2.AreaRegion on region.RegionID equals areaRegion.RegionID
                        join area in _context2.Area on areaRegion.AreaID equals area.AreaID
                        where areaRegion.AreaID == id
                        select new { region, areaRegion, area };
            var data = query.Select(x => new RegionDTO
            {
                RegionID = x.region.RegionID,
                RegionName = x.region.RegionName,
                Area = x.area.AreaName,
            });

            return await data.ToListAsync();
        }
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns></returns>
        public async Task<List<RegionDTO>> GetRegions()
        {
            var query = from region in _context2.Region
                        join ar in _context2.AreaRegion on region.RegionID equals ar.RegionID
                        join area in _context2.Area on ar.AreaID equals area.AreaID
                        select new { region,ar, area };
            var data = query.Select(x => new RegionDTO
            {
                RegionID = x.ar.RegionID,
                RegionName = x.region.RegionName,
                Area = x.area.AreaName,
            });
            return await data.ToListAsync();
        }
    }
}

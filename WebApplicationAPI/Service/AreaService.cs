using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// get area 
    /// </summary>
    /// <param name="context2"></param>
    public class AreaService(AppDbContext2 context2) : IAreaService
    {
        private readonly AppDbContext2 _context2 = context2;
        /// <summary>
        /// get area by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<AreaDTO> GetArea(long id)
        {
            var data = await _context2.Area.FirstOrDefaultAsync(x => x.AreaID == id)
             ?? throw new AppException($"Khong ton tai khu vuc co ID :{id}");
           return new AreaDTO
           {
               AreaID = data.AreaID,
               AreaName = data.AreaName,
               ShortName = data.ShortName,
               FullName = data.FullName

           };
           
           
        }
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        public async Task<List<AreaDTO>> GetAreas()
        {
            var query = _context2.Area.Select(x => new AreaDTO
            {
                AreaID = x.AreaID,
                AreaName = x.AreaName,
                FullName = x.FullName
            });
            return await query.ToListAsync();
        }

    }
}

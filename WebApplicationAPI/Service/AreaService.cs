using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    public class AreaService(AppDbContext2 context2) : IAreaService
    {
        private readonly AppDbContext2 _context2 = context2;
        public async Task<AreaDTO> GetArea(long id)
        {
            var data = await _context2.Area.FirstOrDefaultAsync(x => x.AreaID == id)
             ?? throw new AppException($"Khong ton tai khu vuc co ID :{id}");
           return new AreaDTO
           {
               AreaID = data.AreaID,
               AreaName = data.AreaName,
               FullName = data.FullName

           };
           
           
        }

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

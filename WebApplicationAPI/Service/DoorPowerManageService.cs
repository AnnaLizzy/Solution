using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    public class DoorPowerManageService(AppDbContext2 appDbContext2) : IDoorPowerMangeService
    {
        private readonly AppDbContext2 _context2 = appDbContext2;
        public async Task<List<DoorPowerManageDTO>> GetDoorPowerManager()
        {
           var query  =  _context2.DoorPowerManage.Select(x => new DoorPowerManageDTO
           {
                DoorPowerManageID = x.DoorPowerManageID,
                EmployeeNo = x.EmployeeNo,
                EmployeeName = x.EmployeeName,
                BU = x.BU,
                BGID = x.BGID,
                Tel = x.Tel == null || x.Tel == "0" ? "N/A" : x.Tel.ToString(),
                Dept = x.Dept,
                Position = x.Position,
                Notes = x.Notes,
                Picture = x.Picture,
                EnglishPicture = x.EnglishPicture,
            });
            return await query.ToListAsync();
        }
        /// <summary>
        /// Get doorpower manager
        /// </summary>
        /// <param name="bgId"></param>
        /// <returns></returns>
        public async Task<List<DoorPowerManageDTO>> GetDoorPowerManager(int bgId)
        {
            var query = await _context2.DoorPowerManage
                      .Where(x => x.BGID == bgId)
                      .Select(x => new DoorPowerManageDTO
                      {
                          DoorPowerManageID = x.DoorPowerManageID,
                          EmployeeNo = x.EmployeeNo,
                          EmployeeName = x.EmployeeName,
                          BGID = x.BGID,
                          BU = x.BU,
                          Tel = x.Tel == null || x.Tel == "0" ? "N/A" : x.Tel.ToString(),
                          Dept = x.Dept,
                          Position = x.Position,
                          Notes = x.Notes,
                          Picture = x.Picture,
                          EnglishPicture = x.EnglishPicture,
                      }).ToListAsync();
            return query;
        }
    }
}

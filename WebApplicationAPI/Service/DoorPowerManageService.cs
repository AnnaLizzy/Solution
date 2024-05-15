using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Door power manager
    /// </summary>
    /// <param name="appDbContext2"></param>
    public class DoorPowerManageService(AppDbContext2 appDbContext2) : IDoorPowerMangeService
    {
        private readonly AppDbContext2 _context2 = appDbContext2;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// get by empno
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        //public async Task<DoorPowerManageDTO> GetDoorPowerManagerByEmp(string empNo)
        //{
        //    var query = await _context2.DoorPowerManage
        //                .Where(x => x.EmployeeNo == empNo)
        //                .Select(x => new DoorPowerManageDTO
        //                {
        //                    EmployeeName = x.EmployeeName,
        //                }).ToListAsync();
            
        //}
    }
}

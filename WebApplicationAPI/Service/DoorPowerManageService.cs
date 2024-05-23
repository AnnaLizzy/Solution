using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
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
            var query = _context2.DoorPowerManage.Select(x => new DoorPowerManageDTO
            {
                DoorPowerManageID = x.DoorPowerManageID,
                EmployeeNo = x.EmployeeNo,
                EmployeeName = x.EmployeeName,
                BU = x.BU,
                BGID = x.BGID,
                Tel = x.Tel == null || x.Tel == "0" ? "N/A" : x.Tel.ToString(),
                Dept = x.Dept,
                Position = x.Position,
                Notes = x.Notes != null ? Regex.Replace(x.Notes, @"\r\n?|\n", " ").Trim() : null,
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
                          Notes = x.Notes != null ? Regex.Replace(x.Notes, @"\r\n?|\n", " ").Trim() : null,
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
        public async Task<DoorPowerManageDTO> GetDoorPowerManagerByEmp(string empNo)
        {
            
            var query = from e in _context2.DoorPowerManage
                        where e.EmployeeNo == empNo
                        select new DoorPowerManageDTO
                        {
                            DoorPowerManageID = e.DoorPowerManageID,
                            EmployeeNo = e.EmployeeNo,
                            EmployeeName = e.EmployeeName,
                            BGID = e.BGID,
                            BU = e.BU,
                            Tel = e.Tel == null || e.Tel == "0" ? "N/A" : e.Tel.ToString(),
                            Dept = e.Dept,
                            Position = e.Position,
                            Notes = e.Notes != null ? Regex.Replace(e.Notes, SystemConstants.AppSetting.regexPattern, " ").Trim() : null,
                            Picture = e.Picture,
                            EnglishPicture = e.EnglishPicture,
                        };
            var result = await query.FirstOrDefaultAsync()
                ?? throw new AppException($"Không tìm thấy thông tin quản lý của mã nhân viên '{empNo}'.");
            return result;
        }
    }
}

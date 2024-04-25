using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;


namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Get User
    /// </summary>
    /// <param name="appDbContext2"></param>
    public class UserBeforeLoadingService(AppDbContext2 appDbContext2) : IUserBeforeLoadingService
    {
        private readonly AppDbContext2 _context = appDbContext2;

        /// <summary>
        /// get all User
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserBeforeLodingDTO>> GetUserBeforeLoading()
        {
            var data = await _context.UserBeforeLoding
                .Select(x => new UserBeforeLodingDTO
                {
                    UserBeforeLodingID = x.UserBeforeLodingID,
                    BGID = x.BGID,
                    EmployeeNo = x.EmployeeNo,
                    EmployeeName = x.EmployeeName,
                    BUCode = x.BUCode,
                    Notes = x.Notes,
                    CreateTime = x.CreateTime,
                }).ToListAsync();   
            return data;
        }
        /// <summary>
        /// Get User by BGID
        /// </summary>
        /// <param name="bgid"></param>
        /// <returns></returns>
        public async Task<List<UserBeforeLodingDTO>> GetUserBeforeLoadingByBG(int bgid)
        {
            var data = await _context.UserBeforeLoding.Where(x => x.BGID == bgid)
                    .Select(x => new UserBeforeLodingDTO
                    {
                     UserBeforeLodingID = x.UserBeforeLodingID,
                    BGID = x.BGID,
                    EmployeeNo = x.EmployeeNo,
                    EmployeeName = x.EmployeeName,
                    BUCode = x.BUCode == null || x.BUCode  == "1" ? "N/A" : x.BUCode.ToString(),
                    Notes = x.Notes,
                    CreateTime = x.CreateTime,
                   
                }).ToListAsync();
            return data;
        }
    }
}

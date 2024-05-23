using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;
using WebApplicationAPI.Data;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Models;
namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Ca làm việc 
    /// </summary>
    /// <param name="context"></param>
    public class WorkShiftService(AppDbContext context) : IWorkShiftService
    {
        private readonly AppDbContext _context = context;
        /// <summary>
        /// Tạo ca làm việc mới
        /// </summary>
        /// <param name="workShift"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task CreateWorkShift(WorkShiftDTO workShift)
        {
            if(workShift == null)
            {
                throw new AppException("Vui lòng nhập thông tin ca trực");
            }
            // Kiểm tra xem tên ca trực đã tồn tại chưa
              var existingShift = await _context.WorkShift.FirstOrDefaultAsync(w => w.NameShift == workShift.NameShift);
            if (existingShift != null)
            {
                // Nếu tên ca trực đã tồn tại, trả về lỗi
                throw new AppException("Đã tồn tại tên ca trực này rồi");
            }

            // Chuyển đổi WorkShiftDTO thành WorkShift
            var newWorkShift = new WorkShift
            {
               
                NameShift = workShift.NameShift,
                DescriptionShift = workShift.DescriptionShift,
                StartTime = workShift.StartTime,
                EndTime = workShift.EndTime
            };

            // Thêm ca trực mới vào cơ sở dữ liệu
            _context.WorkShift.Add(newWorkShift);
            await  _context.SaveChangesAsync();
        }
        /// <summary>
        /// delete workshift
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteWorkShift(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lấy thông tin ca làm việc theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<WorkShiftDTO> GetWorkShiftByID(int id)
        {
            var query = await _context.WorkShift.SingleOrDefaultAsync(ws => ws.ShiftID == id)
                ?? throw new AppException("Không tìm thấy ca làm việc này");
            var workShift = new WorkShiftDTO
            {
                ShiftID = query.ShiftID,
                NameShift = query.NameShift,
                DescriptionShift = query.DescriptionShift,
                StartTime = query.StartTime,
                EndTime = query.EndTime
            };
            return workShift;
        }
        /// <summary>
        /// get all workshift
        /// </summary>
        /// <returns></returns>
        public async Task<List<WorkShiftDTO>> GetWorkShifts()
        {
            var query = _context.WorkShift
            .Select(ws => new WorkShiftDTO
            {
                ShiftID = ws.ShiftID,
                NameShift = ws.NameShift,
                DescriptionShift = ws.DescriptionShift,
                StartTime = ws.StartTime,
                EndTime = ws.EndTime
            });
         

            var workShifts = await query.ToListAsync();

            return workShifts;
        }
        /// <summary>
        /// update workshift
        /// </summary>
        /// <param name="workShift"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateWorkShift(WorkShiftDTO workShift)
        {
            throw new NotImplementedException();
        }
    }
}

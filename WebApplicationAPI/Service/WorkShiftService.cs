using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interfaces;
using WebApplicationAPI.Data;
using WebApplicationAPI.Exception;
using WebApplicationAPI.Models;
namespace WebApplicationAPI.Service
{
    public class WorkShiftService : IWorkShiftService
    {
        private readonly AppDbContext _context;
        public WorkShiftService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateWorkShift(WorkShiftDTO workShift)
        {
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
                ShiftID = workShift.ShiftID,
                NameShift = workShift.NameShift,
                DescriptionShift = workShift.DescriptionShift,
                StartTime = workShift.StartTime,
                EndTime = workShift.EndTime
            };

            // Thêm ca trực mới vào cơ sở dữ liệu
            _context.WorkShift.Add(newWorkShift);
            await  _context.SaveChangesAsync();
        }

        public Task DeleteWorkShift(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkShiftDTO> GetWorkShiftByID(int id)
        {
            var query = await _context.WorkShift.FirstOrDefaultAsync(ws => ws.ShiftID == id)
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

        public Task UpdateWorkShift(WorkShiftDTO workShift)
        {
            throw new NotImplementedException();
        }
    }
}

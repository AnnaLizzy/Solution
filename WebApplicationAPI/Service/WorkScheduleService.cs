using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Models;
using WebApplicationAPI.Service.Interfaces;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Service
{
    public class WorkScheduleService(AppDbContext appDb) : IWorkScheduleService
    {
        private readonly AppDbContext _context = appDb;

        public async Task<ApiResult<bool>> CreateWorkSchedule(WorkScheduleDTO model)
        {
            var shift = _context.WorkShift.FirstOrDefault(x => x.ShiftID == model.ShiftID) ?? throw new AppException("Khong ton tai ca lam viec nay");
            var location = _context.Locations.FirstOrDefault(x => x.LocationID == model.LocationID) ?? throw new AppException("Khong ton tai vi tri lam viec nay");
            //var dataLocation = await _context.Locations
            //    .Where(locations => locations.ListID == model.ListId)
            //    .Select(locations => locations.LocationID)
            //    .FirstOrDefaultAsync();
            var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == model.EmployeeID) ?? throw new AppException("Khong ton tai nhan vien nay");
            var newWorkSchedule = new WorkSchedules
            {
                EmployeeID = model.EmployeeID,
                ShiftID = model.ShiftID,
                LocationID = model.LocationID,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Frequency = model.Frequency,
                Interval = model.Interval,
                ByWeekday = model.ByWeekday,
            };
            _context.WorkSchedules.Add(newWorkSchedule);
            var result = await _context.SaveChangesAsync();
           result = result > 0 ? 1 : 0;
            return new ApiResult<bool>
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Tạo lịch làm việc thành công" : "Tạo lịch làm việc thất bại"
            };  
        }

        public Task DeleteWorkSchedule(int id)
        {
            var query = _context.WorkSchedules.FirstOrDefault(x => x.SchedulesID == id) ;
           if(query != null)
            {
                _context.WorkSchedules.Remove(query);
                return _context.SaveChangesAsync();
            }
            throw new AppException("Khong ton tai lich lam viec nay");
        }

        public async Task<WorkScheduleDTO> GetWorkSchedule(int id)
        {
            var query = await _context.WorkSchedules.FirstOrDefaultAsync(x => x.SchedulesID == id) ?? throw new AppException("Khong ton tai lich lam viec nay");
            var model = from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.LocationID equals location.LocationID
                        where workSchedule.SchedulesID == id
                        select new WorkScheduleDTO
                        {
                            SchedulesID = workSchedule.SchedulesID,
                            EmployeeName = employee.EmployeeName,
                            ShiftName = workShift.NameShift,
                            LocationID = workSchedule.LocationID,
                            LocationName = location.LocationName,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday
                        };
            return model.FirstOrDefault() ?? throw new AppException("No data");
        }

        public async Task<WorkScheduleDTO> GetWorkScheduleByEmployeeId(int id)
        {
            var query =  _context.WorkSchedules.FirstOrDefault(x => x.EmployeeID == id) 
                ?? throw new AppException("Khong ton tai lich lam viec nay");
            var model = await( from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.LocationID equals location.LocationID
                        where workSchedule.EmployeeID == id
                        select new WorkScheduleDTO
                        {
                            SchedulesID = workSchedule.SchedulesID,
                            EmployeeName = employee.EmployeeName,
                            ShiftName = workShift.NameShift,
                            LocationID = workSchedule.LocationID,
                            LocationName = location.LocationName,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday
                        }).ToListAsync();
            return model.FirstOrDefault() ?? throw new AppException("No data");
        }

        public async Task<List<WorkScheduleDTO>> GetWorkScheduleByLocationId(string id)
        {
           var query =  _context.WorkSchedules.Where(x => x.LocationID == id) ?? throw new AppException("Khong ton tai lich lam viec nay");
            var model = await (from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.LocationID equals location.LocationID
                        where workSchedule.LocationID == id
                        select new WorkScheduleDTO
                        {
                            SchedulesID = workSchedule.SchedulesID,
                            EmployeeName = employee.EmployeeName,
                            ShiftName = workShift.NameShift,
                            LocationID = workSchedule.LocationID,
                            LocationName = location.LocationName,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday
                        }).ToListAsync();
            return model ?? throw new AppException("No data");
        }

        public async Task<List<WorkScheduleDTO>> GetWorkSchedules()
        {
            
            var query = from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.LocationID equals location.LocationID
                        select new WorkScheduleDTO
                        {
                            SchedulesID = workSchedule.SchedulesID,
                            EmployeeName = employee.EmployeeName,
                            ShiftName = workShift.NameShift,
                            LocationID = workSchedule.LocationID,
                            LocationName = location.LocationName,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateWorkSchedule(int id, WorkScheduleDTO model)
        {
            var query = _context.WorkSchedules.FirstOrDefault(x => x.SchedulesID == id) ?? throw new AppException("Khong ton tai lich lam viec nay");
            var shift = _context.WorkShift.FirstOrDefault(x => x.ShiftID == model.ShiftID) ?? throw new AppException("Khong ton tai ca lam viec nay");
            var location = _context.Locations.FirstOrDefault(x => x.LocationID == model.LocationID) ?? throw new AppException("Khong ton tai vi tri lam viec nay");
            var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == model.EmployeeID) ?? throw new AppException("Khong ton tai nhan vien nay");
            query.EmployeeID = model.EmployeeID;
            query.ShiftID = model.ShiftID;
            query.LocationID = model.LocationID;
            query.StartTime = model.StartTime;
            query.EndTime = model.EndTime;
            query.Frequency = model.Frequency;
            query.Interval = model.Interval;
            query.ByWeekday = model.ByWeekday;
             _context.WorkSchedules.Update(query);
            await _context.SaveChangesAsync();
        }
    }
}

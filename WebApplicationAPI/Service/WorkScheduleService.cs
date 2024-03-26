using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exception;
using WebApplicationAPI.Models;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    public class WorkScheduleService(AppDbContext appDb,AppDbContext2 appDb2) : IWorkScheduleService
    {
        private readonly AppDbContext _context = appDb;
        private readonly AppDbContext2 _context2 = appDb2;
        public Task CreateWorkSchedule( WorkScheduleDTO model)
        {
           
            var shift = _context.WorkShift.FirstOrDefault(x => x.ShiftID == model.ShiftID) ?? throw new AppException("Khong ton tai ca lam viec nay");
            var location = _context.Locations.FirstOrDefault(x => x.LocationID == model.LocationID) ?? throw new AppException("Khong ton tai vi tri lam viec nay");
            var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == model.EmployeeID) ?? throw new AppException("Khong ton tai nhan vien nay");
            var newWorkSchedule = new WorkScheduleDTO
            {
                EmployeeID = model.EmployeeID,
                ShiftID = model.ShiftID,
                LocationID = model.LocationID,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };
            return Task.CompletedTask;
        }

        public Task DeleteWorkSchedule(int id)
        {
            var query = _context.WorkSchedules.FirstOrDefault(x => x.SchedulesID == id) ?? throw new AppException("Khong ton tai lich lam viec nay");
            _context.WorkSchedules.Remove(query);
            return Task.CompletedTask;
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
                            EndTime = workSchedule.EndTime
                        };
            return model.FirstOrDefault() ?? throw new AppException("No data");
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
                            EndTime = workSchedule.EndTime
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

             _context.WorkSchedules.Update(query);
            await _context.SaveChangesAsync();
        }
    }
}

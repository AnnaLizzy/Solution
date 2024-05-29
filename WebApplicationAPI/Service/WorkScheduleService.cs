namespace WebApplicationAPI.Service
{
    /// <summary>
    /// work schedule service
    /// </summary>
    /// <param name="appDb"></param>
    public class WorkScheduleService(AppDbContext appDb) : IWorkScheduleService
    {
        private readonly AppDbContext _context = appDb;
        /// <summary>
        /// create work schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<ApiResult<bool>> CreateWorkSchedule(WorkScheduleDTO model)
        {
            var shift = _context.WorkShift.FirstOrDefault(x => x.ShiftID == model.ShiftID) 
                ?? throw new AppException("Does not exist this work shift");
            var location = _context.Locations.FirstOrDefault(x => x.ListID == model.ListID)
                ?? throw new AppException("Does not exist this location");
            var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == model.EmployeeID) 
                ?? throw new AppException("Does not exist this employee");
            var newWorkSchedule = new WorkSchedules
            {
                ScheduleID = model.ScheduleID,
                ShiftID = model.ShiftID,
                ListID = model.ListID,
                EmployeeName = employee.EmployeeName,
                BG = model.BG,
                BU = model.BU,
                PhoneNumber = model.PhoneNumber,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Frequency = model.Frequency,
                Interval = model.Interval,
                ByWeekday = model.ByWeekday,
                BUCode = model.BUCode,
                Notes = model.Notes,
                DateCreated = DateTime.Now,
                SignStatus = Status.CHO_KY,
                IsDeleted = false,
                SignBy = model.SignBy
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
        /// <summary>
        /// delete work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public Task DeleteWorkSchedule(int id)
        {
            var query = _context.WorkSchedules.FirstOrDefault(x => x.ScheduleID == id) ;
           if(query != null)
            {
                _context.WorkSchedules.Remove(query);
                return _context.SaveChangesAsync();
            }
            throw new AppException("Does not exist this work schedule !");
        }
        /// <summary>
        /// get work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<WorkScheduleDTO> GetWorkSchedule(int id)
        {
            var query = await _context.WorkSchedules.FirstOrDefaultAsync(x => x.ScheduleID == id)
                ?? throw new AppException("Does not exist this work schedule !");
            var model = from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.ListID equals location.ListID
                        where workSchedule.ScheduleID == id
                        select new WorkScheduleDTO
                        {
                            ScheduleID = workSchedule.ScheduleID,                          
                            ListID = workSchedule.ListID,
                            EmployeeID = workSchedule.EmployeeID,
                            ShiftName = workShift.NameShift,
                            BG = workSchedule.BG,
                            BU = workSchedule.BU,
                            PhoneNumber = workSchedule.PhoneNumber,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday,
                            BUCode = workSchedule.BUCode,
                            Notes = workSchedule.Notes,
                            SignBy = workSchedule.SignBy,
                            SignStatus = workSchedule.SignStatus,
                            DateCreated = workSchedule.DateCreated,
                            EmployeeNo = workSchedule.EmployeeNo,
                            IsDeleted = workSchedule.IsDeleted,
                            DateModified = workSchedule.DateModified,
                           
                        };
            return model.FirstOrDefault() ?? throw new AppException("No data");
        }
        /// <summary>
        /// get work schedule by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<WorkScheduleDTO> GetWorkScheduleByEmployeeId(int id)
        {
            var query =  _context.WorkSchedules.FirstOrDefault(x => x.EmployeeID == id) 
                ?? throw new AppException("Does not exist this work schedule !");
            var model = await( from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.ListID equals location.ListID
                        where workSchedule.EmployeeID == id
                        select new WorkScheduleDTO
                        {
                            ScheduleID = workSchedule.ScheduleID,
                            EmployeeName = employee.EmployeeName,
                            EmployeeNo = workSchedule.EmployeeNo,
                            BG = workSchedule.BG,
                            BU = workSchedule.BU,
                            PhoneNumber = workSchedule.PhoneNumber,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday,
                            BUCode = workSchedule.BUCode,
                            Notes = workSchedule.Notes,
                            SignBy = workSchedule.SignBy,
                            SignStatus = workSchedule.SignStatus,
                            DateCreated = workSchedule.DateCreated,
                            IsDeleted = workSchedule.IsDeleted,
                            DateModified = workSchedule.DateModified,
                        }).ToListAsync();
            return model.FirstOrDefault() ?? throw new AppException("No data");
        }
        /// <summary>
        /// get work schedule by location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<List<WorkScheduleDTO>> GetWorkScheduleByLocationId(string id)
        {
           var query =  _context.WorkSchedules.Where(x => x.ListID.ToString() == id)
                ?? throw new AppException("Does not exist !");
            var model = await (from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.ListID equals location.ListID
                        where workSchedule.ListID.ToString() == id
                        select new WorkScheduleDTO
                        {
                            ScheduleID = workSchedule.ScheduleID,
                            EmployeeID = workSchedule.EmployeeID,
                            EmployeeNo = workSchedule.EmployeeNo,
                            BG = workSchedule.BG,
                            BU = workSchedule.BU,
                            PhoneNumber = workSchedule.PhoneNumber,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday,
                            BUCode = workSchedule.BUCode,
                            Notes = workSchedule.Notes,
                            SignBy = workSchedule.SignBy,
                            SignStatus = workSchedule.SignStatus,
                        }).ToListAsync();
            return model ?? throw new AppException("No data");
        }
        /// <summary>
        /// get all work schedules
        /// </summary>
        /// <returns></returns>
        public async Task<List<WorkScheduleDTO>> GetWorkSchedules()
        {
            
            var query = from workSchedule in _context.WorkSchedules
                        join employee in _context.Employee on workSchedule.EmployeeID equals employee.EmployeeID
                        join workShift in _context.WorkShift on workSchedule.ShiftID equals workShift.ShiftID
                        join location in _context.Locations on workSchedule.ListID equals location.ListID
                        select new WorkScheduleDTO
                        {
                            ScheduleID = workSchedule.ScheduleID,
                            EmployeeName = employee.EmployeeName,
                            ShiftName = workShift.NameShift,                        
                            LocationName = location.LocationName,
                            StartTime = workSchedule.StartTime,
                            EndTime = workSchedule.EndTime,
                            Frequency = workSchedule.Frequency,
                            Interval = workSchedule.Interval,
                            ByWeekday = workSchedule.ByWeekday
                        };
            return await query.ToListAsync();
        }
        /// <summary>
        /// update work schedule by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task UpdateWorkSchedule(int id, WorkScheduleDTO model)
        {
            var query = _context.WorkSchedules.FirstOrDefault(x => x.ScheduleID == id) 
                ?? throw new AppException("Does not exist this work schedule");
            var shift = _context.WorkShift.FirstOrDefault(x => x.ShiftID == model.ShiftID) 
                ?? throw new AppException("Does not exist this work shift");
            var location = _context.Locations.FirstOrDefault(x => x.ListID == model.ListID)
                ?? throw new AppException("Does not exist this location");
            var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == model.EmployeeID) 
                ?? throw new AppException("Does not exist this employee");
            query.EmployeeID = model.EmployeeID;
            query.ShiftID = model.ShiftID;
           // query.LocationID = model.LocationID;
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

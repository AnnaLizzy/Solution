using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.Enum;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Dia diem truc của database Teststat
    /// </summary>
    /// <param name="appContext"></param>
    /// <param name="appContext2"></param>
    public class LocationService(AppDbContext appContext, AppDbContext2 appContext2) : ILocationService
    {
        private readonly AppDbContext appDbContext = appContext;
        private readonly AppDbContext2 appDbContext2 = appContext2;
       /// <summary>
       /// Create 
       /// </summary>
       /// <param name="locationDTO"></param>
       /// <returns></returns>
       /// <exception cref="ArgumentNullException"></exception>
       /// <exception cref="AppException"></exception>
        public async Task<int> CreateLocation(LocationDTO locationDTO)
        {
            if (locationDTO == null)
            {
                throw new ArgumentNullException(nameof(locationDTO), "Location is null.");
            }

            // Kiểm tra xem vị trí đã tồn tại chưa
            var existingLocationName = await appDbContext.Locations.FirstOrDefaultAsync(x => x.LocationName == locationDTO.LocationName);
            if (existingLocationName != null)
            {
                throw new AppException("Location Name already exists.");
            }

            // Tạo đối tượng Location mới
            var newLocation = new Models.Locations
            {
                LocationID = locationDTO.LocationID,
                LocationName = locationDTO.LocationName,
                Area = locationDTO.Area,
                Floors = locationDTO.Floors,
                Region = locationDTO.Region,
                Building = locationDTO.Building,
                Azimuth = locationDTO.Azimuth,
                StationType = locationDTO.StationType,
                Other = locationDTO.Other,
                StartTime = locationDTO.StartTime,
                EndTime = locationDTO.EndTime,
                SignStatus = Status.CHO_KY,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                SignUser = locationDTO.SignUser,
                EmployeeNo = locationDTO.EmployeeNo,
            };

            // Thêm mới vị trí vào cơ sở dữ liệu
            appDbContext.Locations.Add(newLocation);
            try
            {
                await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Ghi lại lỗi và xử lý ngoại lệ
                // Ví dụ: logger.LogError(ex, "An error occurred while creating the location.");
                throw new AppException("An error occurred while creating the location.", ex);
            }
            return newLocation.ListID;
        }


        /// <summary>
        /// Xoa dia diem theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<int> DeleteLocation(int id)
        {
            var query = await appDbContext.Locations.FirstOrDefaultAsync(x => x.ListID == id)
                        ?? throw new AppException("Location do not exist");

            appDbContext.Locations.Remove(query);

            try
            {
                return await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Ghi nhật ký hoặc xử lý ngoại lệ
                // Ví dụ: logger.LogError(ex, "An error occurred while deleting the location.");
                throw new AppException("An error occurred while deleting the location.", ex);
            }
        }
        /// <summary>
        /// Get dia diem theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<LocationDTO> GetLocation(int id)
        {
            // Truy vấn từ context đầu tiên
            var location = await appDbContext.Locations
                                              .Where(a => a.ListID == id)
                                              .SingleOrDefaultAsync() 
                                              ?? throw new AppException($"Cannot find location with id: {id}");
            // Truy vấn từ context thứ hai
            var area = await appDbContext2.Area
                                          .Where(b => b.AreaName == location.Area)
                                          .SingleOrDefaultAsync();
            var region = await appDbContext2.Region
                                          .Where(b => b.RegionName == location.Region)
                                          .SingleOrDefaultAsync();
            var data = new LocationDTO
            {
                ListID = location.ListID,
                LocationID = location.LocationID,
                LocationName = location.LocationName,
                Area = location.Area,
                AreaID = area?.AreaID ?? 0,
                RegionID = region?.RegionID ?? 0,
                Floors = location.Floors,
                Region = location.Region,
                Building = location.Building,
                Azimuth = location.Azimuth,
                StationType = location.StationType,
                Other = location.Other,
                StartTime = location.StartTime,
                EndTime = location.EndTime,
                SignStatus = location.SignStatus,
                SignDate = location.SignDate,
                SignUser = location.SignUser,
                CreateTime = location.CreateTime,
                UpdateTime = location.UpdateTime,
                EmployeeNo = location.EmployeeNo,
            };    

            return data ?? throw new AppException($"Cannot find location with id: {id}");
        }
        /// <summary>
        /// get địa điểm 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<List<LocationDTO>> GetLocations()
        {
            var query = await appDbContext.Locations
                              .Select(x => new LocationDTO
                              {
                                  ListID = x.ListID,
                                  LocationID = x.LocationID,
                                  LocationName = x.LocationName ?? "N/A",
                                  Area = x.Area ?? "N/A",
                                  Floors = x.Floors ?? "N/A",
                                  Region = x.Region ?? "N/A",
                                  Building = x.Building ?? "N/A",
                                  Azimuth = x.Azimuth ?? "N/A",
                                  StationType = x.StationType ?? "N/A",
                                  Other = x.Other ?? "N/A",
                                  StartTime = x.StartTime,
                                  EndTime = x.EndTime,
                                  SignStatus = x.SignStatus == default ? Status.Unknown : x.SignStatus,
                                  CreateTime = x.CreateTime,
                                  UpdateTime = x.UpdateTime,
                              })
                              .ToListAsync();

            return query ?? throw new AppException("No data available");
        }
        /// <summary>
        /// Sign location
        /// </summary>
        /// <param name="id"></param>    
        /// <param name="location"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<int> SignLocation(int id, SignLocationDTO location)
        {
            // Kiểm tra đầu vào
            ArgumentNullException.ThrowIfNull(location);

            // Tìm kiếm vị trí theo ID
            var query = appDbContext.Locations.FirstOrDefault(x => x.ListID == id)
                        ?? throw new AppException("Không tìm thấy vị trí này");

            // Tạo bản ghi log ký người dùng
            var log = new LogSignUser
            {
                SignUser = location.SignUser,
                EMail = "", // Địa chỉ email cần thay đổi tùy theo ngữ cảnh
                Body = "this is body", // Nội dung body cần thay đổi tùy theo ngữ cảnh
                SignSubject = "Tieu de", // Tiêu đề cần thay đổi tùy theo ngữ cảnh
                SignStatus = location.SignStatus,
                Notes = location.Notes, // Ghi chú cần thay đổi tùy theo ngữ cảnh
                ListID = id,
            };
            try
            {
                // Thêm bản ghi log vào bảng LogSignUser
                appDbContext.LogSignUser.Add(log);

                // Cập nhật trạng thái ký và ngày ký của vị trí
                query.SignStatus = location.SignStatus;
                query.SignDate = DateTime.Now;

                // Cập nhật bảng Locations
                appDbContext.Locations.Update(query);

                // Lưu thay đổi vào cơ sở dữ liệu
                return await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và log lỗi
                // Log lỗi nếu cần thiết (ví dụ: logger.LogError(ex, "Error occurred while signing location"))
                throw new AppException("Đã xảy ra lỗi khi ký vị trí", ex);
            }
        }


        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="AppException"></exception>
        public async Task<int> UpdateLocation(int id, LocationDTO locationDTO)
        {
            // Kiểm tra đầu vào
            if (locationDTO == null)
            {
                throw new AppException("Vui lòng nhập thông tin vị trí");
            }

            // Tìm kiếm vị trí theo ID
            var query = await appDbContext.Locations.FirstOrDefaultAsync(x => x.ListID == id)
                        ?? throw new AppException("Không tìm thấy vị trí này");

            // Cập nhật thông tin vị trí với dữ liệu từ DTO
            query.LocationID = locationDTO.LocationID;
            query.LocationName = locationDTO.LocationName;
            query.Area = locationDTO.Area;
            query.Floors = locationDTO.Floors;
            query.Region = locationDTO.Region;
            query.Building = locationDTO.Building;
            query.Azimuth = locationDTO.Azimuth;
            query.StationType = locationDTO.StationType;
            query.Other = locationDTO.Other;
            query.StartTime = locationDTO.StartTime;
            query.EndTime = locationDTO.EndTime;
            query.SignStatus = Status.CHO_KY; // Đặt trạng thái ký là "CHỜ KÝ"
            query.UpdateTime = DateTime.Now; // Cập nhật thời gian
            query.SignUser = locationDTO.SignUser;

            try
            {
                // Cập nhật bảng Locations
                appDbContext.Locations.Update(query);

                // Lưu thay đổi vào cơ sở dữ liệu
                return await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và log lỗi
                // Log lỗi nếu cần thiết (ví dụ: logger.LogError(ex, "Đã xảy ra lỗi khi cập nhật vị trí"))
                throw new AppException("Đã xảy ra lỗi khi cập nhật vị trí", ex);
            }
        }


    }
}

using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Models.Enum;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Dia diem truc của database Teststat
    /// </summary>
    /// <param name="appContext"></param>

    public class LocationService(AppDbContext appContext) : ILocationService
    {
        private readonly AppDbContext _context = appContext;

        /// <summary>
        /// Tao dia diem
        /// </summary>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<int> CreateLocation(LocationDTO locationDTO)
        {
            var existingLocationName = await _context.Locations.FirstOrDefaultAsync(x => x.LocationName == locationDTO.LocationName);
            if (existingLocationName != null)
            {
                throw new AppException("Location Name already exists.");
            }
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

           var result =  _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();
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
            var query = _context.Locations.FirstOrDefault(x => x.ListID == id) ?? throw new AppException("Khong ton tai dia diem nay");
              _context.Locations.Remove(query);
            return await _context.SaveChangesAsync();
          
        }
        /// <summary>
        /// get địa điểm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<LocationDTO> GetLocation(int id)
        {
            var location = await _context.Locations.Select(x => new LocationDTO
            {
                ListID = x.ListID,
                LocationID = x.LocationID,
                LocationName = x.LocationName,
                Area = x.Area,               
                Floors = x.Floors,               
                Region = x.Region,
                Building = x.Building,
                Azimuth = x.Azimuth,
                StationType = x.StationType,
                Other = x.Other,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                SignStatus = x.SignStatus,
                SignDate = x.SignDate,
                SignUser = x.SignUser,

            }).FirstOrDefaultAsync(x => x.ListID == id) ?? throw new System.Exception($"Cannot found location id :{id}");
            return location;
        }
        /// <summary>
        /// get địa điểm 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<List<LocationDTO>> GetLocations()
        {
            var query = await _context.Locations                                 
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
                                     StartTime = x.StartTime ,
                                     EndTime = x.EndTime,
                                     SignStatus = x.SignStatus == default ? Status.Unknown : x.SignStatus,
                                     CreateTime = x.CreateTime ,
                                     UpdateTime = x.UpdateTime,
                                 })
                                 .ToListAsync();
            if (query == null || query.Count == 0)
            {
                throw new AppException("Khong co dia diem nao");
            }
            return query;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locationDTO"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task<bool> UpdateLocation(int id, LocationDTO locationDTO)
        {
            var query = await _context.Locations.FirstOrDefaultAsync(x => x.ListID == id) ?? throw new AppException("Khong ton tai dia diem nay");

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
            query.SignStatus = locationDTO.SignStatus;            
            query.UpdateTime = DateTime.Now;

             _context.Locations.Update(query);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

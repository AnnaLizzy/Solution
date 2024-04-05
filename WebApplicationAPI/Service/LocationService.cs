using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exception;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{

    public class LocationService(AppDbContext appContext) : ILocationService
    {
        private readonly AppDbContext _context = appContext;
       

        public async Task CreateLocation(LocationDTO locationDTO)
        {
            
                var query = await _context.Locations.FirstOrDefaultAsync(x => x.LocationName == locationDTO.LocationName );
                if (query != null)
                {
                    throw new AppException("Location Name has exist");
                }
                var checkLocationID = await _context.Locations.FirstOrDefaultAsync(x => x.LocationID == locationDTO.LocationID);
                if (checkLocationID != null)
                {
                        throw new AppException("Location ID has exist");
                    }
                _context.Locations.Add(new Models.Locations
                {
                    ListID = locationDTO.ListID,
                    LocationID = locationDTO.LocationID,
                    LocationName = locationDTO.LocationName,
                    Area = locationDTO.Area,
                    Floors = locationDTO.Floors,
                    X = locationDTO.X,
                    Y = locationDTO.Y,
                    Region = locationDTO.Region,
                });
                await  _context.SaveChangesAsync();
                
           
        }

        public async Task DeleteLocation(int id)
        {
            var query = _context.Locations.FirstOrDefault(x => x.ListID == id) ?? throw new AppException("Khong ton tai dia diem nay");
              _context.Locations.Remove(query);
            await _context.SaveChangesAsync();
          
        }

        public async Task<LocationDTO> GetLocation(int id)
        {
            var location = await _context.Locations.Select(x => new LocationDTO
            {
                ListID = x.ListID,
                LocationID = x.LocationID,
                LocationName = x.LocationName,
                Area = x.Area,               
                Floors = x.Floors,
                X = x.X,
                Y = x.Y,
                Region = x.Region,               
            }).FirstOrDefaultAsync(x => x.ListID == id) ?? throw new System.Exception($"khong tim thay dia diem id :{id}");
            return location;
        }

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
                                     X = x.X ,
                                     Y = x.Y,
                                     Region = x.Region ?? "N/A"
                                 })
                                 .ToListAsync();
            if (query == null || query.Count == 0)
            {
                throw new AppException("Khong co dia diem nao");
            }
            return query;
        }

        public async Task UpdateLocation(int id, LocationDTO locationDTO)
        {
            var query = await _context.Locations.FirstOrDefaultAsync(x => x.ListID == id) ?? throw new AppException("Khong ton tai dia diem nay");

            query.LocationID = locationDTO.LocationID;
            query.LocationName = locationDTO.LocationName;         
            query.Area = locationDTO.Area;
            query.Floors = locationDTO.Floors;
            query.X = locationDTO.X;
            query.Y = locationDTO.Y;
            query.Region = locationDTO.Region;      
            await _context.SaveChangesAsync();
        }

    }
}

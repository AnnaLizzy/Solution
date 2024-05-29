namespace WebApplicationAPI.Service
{
    /// <summary>
    /// List location from OndytyListLocation
    /// </summary>
    /// <param name="appDb"></param>
    public class ListLocationService(AppDbContext2 appDb) : IListLocationService
    {
        private readonly AppDbContext2 _context2 = appDb;
        /// <summary>
        /// create location
        /// </summary>
        /// <param name="listlocationDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ListLocationDTO> CreateLocation(ListLocationDTO listlocationDTO)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// delete location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteLocation(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// get location by area id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ListLocationDTO>> GetLocationByAreaID(int id)
        {
            var query = from l in _context2.OndutyListLocations
                        where l.AreaID == id
                        select new ListLocationDTO
                        {
                            ID = l.ID,
                            LocationID = l.LocationID,
                            LocationAbrevationName = l.LocationAbrevationName,
                            LocationDetailName = l.LocationDetailName,
                            AreaID = l.AreaID,
                            X = l.X,
                            Y = l.Y,
                            IsDeleted = l.IsDeleted
                        };         
            var data = await query.ToListAsync();
            return data;
        }
        /// <summary>
        /// get all locations
        /// </summary>
        /// <returns></returns>
        public async Task<List<ListLocationDTO>> GetLocations()
        {
            var query = _context2.OndutyListLocations.Select(x => new ListLocationDTO
            {
                ID = x.ID,               
                LocationID = x.LocationID,
                LocationAbrevationName = x.LocationAbrevationName,
                LocationDetailName = x.LocationDetailName,
                AreaID = x.AreaID,
                X = x.X,
                Y = x.Y,
                IsDeleted = x.IsDeleted

            });
            var data = await query.ToListAsync();
            return data;
        }
        /// <summary>
        /// update location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listlocationDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateLocation(int id, ListLocationDTO listlocationDTO)
        {
            throw new NotImplementedException();
        }
    }
    
}

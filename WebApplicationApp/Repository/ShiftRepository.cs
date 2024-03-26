using WebApplicationApp.Models;
using WebApplicationApp.Repository.Interface;

namespace WebApplicationApp.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        public Task CreateShift(Shift shift)
        {
            throw new NotImplementedException();
        }

        
        public Task DeleteShift(int? id)
        {
            throw new NotImplementedException();
        }

        
        public Task<List<Shift>> GetAllShifts()
        {
            throw new NotImplementedException();
        }


        public Task<Shift> GetShiftById(int? id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateShift(Shift shift)
        {
            throw new NotImplementedException();
        }

    }
}

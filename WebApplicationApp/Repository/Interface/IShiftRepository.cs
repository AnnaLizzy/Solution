using WebApplicationApp.Models;

namespace WebApplicationApp.Repository.Interface
{
    public interface IShiftRepository
    {
        Task<List<Shift>> GetAllShifts();
        Task<Shift> GetShiftById(int? id);
        Task CreateShift(Shift shift);
        Task UpdateShift(Shift shift);
        Task DeleteShift(int? id);
    }
}

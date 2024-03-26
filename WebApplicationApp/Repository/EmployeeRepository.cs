using Microsoft.EntityFrameworkCore;
using WebApplicationApp.Data;
using WebApplicationApp.Repository.Interface;
using WebApplicationApp.ViewModels;

namespace WebApplicationApp.Repository
{
    public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
    {
        private readonly AppDbContext _context = appDbContext;

        public Task CreateEmployee(EmployeeViewModel employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var query = _context.Employees
                    .Select(e => new EmployeeViewModel
                    {
                        EmployeeID = e.EmployeeID,
                        EmployeeNo = e.EmployeeNo,
                        EmployeeName = e.EmployeeName,
                        Gender = e.Gender,
                        PhoneNumber = e.PhoneNumber,
                        DateOfBirth = e.DateOfBirth,
                        Company = e.Company,
                    });
            return await query.ToListAsync();
        }

        public Task<EmployeeViewModel> GetEmployeeById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(EmployeeViewModel employee)
        {
            throw new NotImplementedException();
        }
    }
}

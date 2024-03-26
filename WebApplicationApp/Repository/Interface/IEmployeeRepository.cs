using WebApplicationApp.ViewModels;

namespace WebApplicationApp.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<EmployeeViewModel> GetEmployeeById(int? id);
        Task CreateEmployee(EmployeeViewModel employee);
        Task UpdateEmployee(EmployeeViewModel employee);
        Task DeleteEmployee(int? id);
    }
}

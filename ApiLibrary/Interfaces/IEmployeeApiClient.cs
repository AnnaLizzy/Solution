using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
   public interface IEmployeeApiClient
    {
        Task<List<EmployeeViewModel>> GetEmployees(string token);
        Task<EmployeeViewModel> GetEmployee(int? id,string token);
        Task<bool> CreateEmployee(EmployeeViewModel employee);
        Task<bool> UpdateEmployee(EmployeeViewModel employee);
        Task<bool> DeleteEmployee(int? id);
    }
}

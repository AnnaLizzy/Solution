using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;




namespace WebApplicationAPI.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResult<string>> Authenticate(LoginDTO model);
        Task<List<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployee(int id);
        Task CreateEmployee( EmployeeDTO employee);
        Task UpdateEmployee(int id, EmployeeDTO employee);
        Task DeleteEmployee(int id);

    }
}

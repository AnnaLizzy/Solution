namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// Get all employees
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="model"></param>      
        /// <returns></returns>
        Task<ApiResult<string>> Authenticate(LoginDTO model);
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDTO>> GetEmployees();
        /// <summary>
        /// get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeDTO> GetEmployee(int id);
        /// <summary>
        /// Create employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task CreateEmployee( EmployeeDTO employee);
        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateEmployee(int id, EmployeeDTO employee);
        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteEmployee(int id);

    }
}

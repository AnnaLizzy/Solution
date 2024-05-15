using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
   public interface IEmployeeApiClient
    {
        Task<List<EmployeeViewModel>> GetEmployees(string token);
        Task<EmployeeViewModel> GetEmployee(int? id);
        Task<bool> CreateEmployee(EmployeeViewModel employee);
        Task<bool> UpdateEmployee(EmployeeViewModel employee);
        Task<bool> DeleteEmployee(int? id);
    }
}

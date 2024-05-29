using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IAccountApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginDTO model);
        Task<ApiResult<string>> RefreshToken(LoginDTO model);
        Task<List<EmployeeDTO>> GetEmployees(string token);
    }
}

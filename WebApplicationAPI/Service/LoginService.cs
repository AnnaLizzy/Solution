using WebApplicationAPI.DTOs;
using WebApplicationAPI.Service.Interface;
using WebApplicationAPI.Service.Interfaces;

namespace WebApplicationAPI.Service
{
    public class LoginService(IEmployeeService employeeService) : ILoginService
    {
        private readonly IEmployeeService _employeeService = employeeService;
        public Task<string> Authenticate(LoginDTO login)
        {
            throw new NotImplementedException();
        }
    }
}

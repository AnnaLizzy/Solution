using WebApplicationAPI.DTOs;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResult<string>> Authenticate(LoginDTO model);
        
    }
}

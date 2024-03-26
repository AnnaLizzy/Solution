using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interface
{
    public interface ILoginService
    {
        Task<string> Authenticate(LoginDTO login);


    }
}

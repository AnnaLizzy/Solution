using WebApplicationAPI.DTOs;

namespace WebApplicationAPI.Service.Interfaces
{
    public interface IUserBeforeLoadingService
    {
        Task<List<UserBeforeLodingDTO>> GetUserBeforeLoading();
        Task<List<UserBeforeLodingDTO>> GetUserBeforeLoadingByBG(int bgid);


    }
}

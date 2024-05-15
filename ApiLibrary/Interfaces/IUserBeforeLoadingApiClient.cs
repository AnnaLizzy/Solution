using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IUserBeforeLoadingApiClient
            {
        Task<List<UserBeforeLoadingViewModel>> GetAll();
        Task<UserBeforeLoadingViewModel> GetById(int id);
    }
}

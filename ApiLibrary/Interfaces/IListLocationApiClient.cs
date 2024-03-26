using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IListLocationApiClient
    {
        Task<List<ListLocationVM>> GetAllLocations();
        Task<List<ListLocationVM>> GetLocation(int id);
    }
}

using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
    public interface IAreaApiClient
    {
        Task<List<AreaViewModel>> GetAreas();
        Task<AreaViewModel> GetArea(int id);
    }
}

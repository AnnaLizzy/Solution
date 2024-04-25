using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
    public interface IRegionApiClient
    {
        Task<List<RegionsViewModel>> GetRegions();
        Task<RegionsViewModel> GetRegion(int id);
    }
}

using ApiLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Interfaces
{
    public interface IPowerManagerApiClient
    {
        Task<List<PowerManagerViewModel>> GetPowerManager();
        Task<PowerManagerViewModel> GetPowerManagerByEmpNo(string empNo);
    }
}

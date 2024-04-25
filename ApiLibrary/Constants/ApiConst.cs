using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Constants
{
    public class ApiConst
    {
        internal class Setting()
        {
            internal const string StringContent = "application/json";
            internal const string Bearer = "Bearer";
        }
        internal class Url()
        {
            public const string LoginUrl = "/api/Account/login";
            public const string GetEmployees = "/api/Account";
        }
    }
}

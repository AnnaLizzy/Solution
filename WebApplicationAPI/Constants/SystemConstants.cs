using System.Runtime.CompilerServices;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Constants
{
    public class SystemConstants
    {
        public class AppSetting()
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
            public const string TokenIssuer = "Tokens:Issuer";
            public const string TokenKey = "Tokens:Key";
            public const string ConnectionString = "Data Source=10.224.69.61;Initial Catalog=CertificateDB;User ID=formsign;Password=1234567Aa;TrustServerCertificate=True;";
        }
        public class Url()
        {
            public const string BaseUrl = "https://localhost:44334/";//WebApp
            public const string BaseApiUrl = "https://localhost:44389/";//Swagger api
        }
        public class Parametters()
        {
            public const string EmployeeNo = "@EmployeeNo";
            public const string Password = "@password";
            public const string empNo = "EmployeeNo";
            public const string pass = "Password";
        }
        public class StoreProceduces()
        {
            public const string CheckLogin = "UP_UserBeforeLoding_loding";
        }
        public class MessageError()
        {
            //Account
            public const string LoginError = "Không tìm thấy người dùng hoặc mật khẩu không chính xác";
            public const string EmployeeErrorExist = "Employee already exist in Database.";
            public const string EmployeeErrorNotExist = "Employee doesn't exist in database.";
            //Area
            public const string AreaError = "Khong ton tai khu vuc co ID :{0}";
        }
    }
}

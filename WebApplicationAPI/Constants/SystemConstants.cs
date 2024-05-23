namespace WebApplicationAPI.Constants
{
    /// <summary>
    /// All constants in system
    /// </summary>
    public class SystemConstants
    {
        /// <summary>
        ///  Constants
        /// </summary>
        public class AppSetting()
        {
            /// <summary>
            /// regrex mail
            /// </summary>
            public const string regexPattern = @"\r\n?|\n";
            /// <summary>
            /// Default language id
            /// </summary>
            public const string DefaultLanguageId = "DefaultLanguageId";
            /// <summary>
            /// Default token
            /// </summary>
            public const string Token = "Token";
            /// <summary>
            /// Base address
            /// </summary>
            public const string BaseAddress = "BaseAddress";
            /// <summary>
            /// issure
            /// </summary>
            public const string TokenIssuer = "Tokens:Issuer";
            /// <summary>
            /// 
            /// </summary>
            public const string TokenKey = "Tokens:Key";
            /// <summary>
            /// 
            /// </summary>
            public const string SecretKey = "SecretKey";
            /// <summary>
            /// Database Tesstat
            /// </summary>
            public const string ConnectionStringDB1 = "DefaultConnection";
            /// <summary>
            /// Database CertificateDB
            /// </summary>
            public const string ConnectionStringDB2 = "Database2Connection";
            /// <summary>
            /// connection string
            /// </summary>
            public const string ConnectionString = "Data Source=10.224.69.61;Initial Catalog=CertificateDB;User ID=formsign;Password=1234567Aa;TrustServerCertificate=True;";
        }
        /// <summary>
        /// Url
        /// </summary>
        public class Url()
        {
            /// <summary>
            /// web app
            /// </summary>
            public const string BaseUrl = "https://localhost:44334/";
            /// <summary>
            /// Swagger api
            /// </summary>
            public const string BaseApiUrl = "https://localhost:44389/";
        }
        /// <summary>
        /// Parametters
        /// </summary>
        public class Parametters()
        {
            /// <summary>
            /// Mã thẻ nhân viên : biến run store proceduce
            /// </summary>
            public const string EmployeeNo = "@EmployeeNo";
            /// <summary>
            /// mật khẩu : biến run store proceduce
            /// </summary>
            public const string Password = "@password";
            /// <summary>
            /// mã thẻ nhân viên 
            /// </summary>
            public const string empNo = "EmployeeNo";
            /// <summary>
            /// mật khẩu
            /// </summary>
            public const string pass = "Password";
        }
        /// <summary>
        /// StoreProceduces
        /// </summary>
        public class StoreProceduces()
        {
            /// <summary>
            /// store proceduce check login
            /// </summary>
            public const string CheckLogin = "UP_UserBeforeLoding_loding";
        }
        /// <summary>
        /// MessageError
        /// </summary>
        public class MessageError()
        {
            /// <summary>
            /// Account
            /// </summary>
            public const string LoginError = "Không tìm thấy người dùng hoặc mật khẩu không chính xác";
            /// <summary>
            /// 
            /// </summary>
            public const string EmployeeErrorExist = "Employee already exist in Database.";
            /// <summary>
            /// 
            /// </summary>
            public const string EmployeeErrorNotExist = "Employee doesn't exist in database.";
            /// <summary>
            /// Area
            /// </summary>
            public const string AreaError = "Khong ton tai khu vuc co ID :";
        }
    }
}

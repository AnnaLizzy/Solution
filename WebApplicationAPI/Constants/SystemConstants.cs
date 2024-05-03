namespace WebApplicationAPI.Constants
{
    public class SystemConstants
    {
        public class AppSetting()
        {
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
            public const string TokenKey = "Tokens:Key";
            public const string SecretKey = "SecretKey";
            public const string ConnectionStringDB1 = "DefaultConnection";
            public const string ConnectionStringDB2 = "Database2Connection";
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
            public const string EmployeeNo = "@EmployeeNo";
            public const string Password = "@password";
            public const string empNo = "EmployeeNo";
            public const string pass = "Password";
        }
        /// <summary>
        /// StoreProceduces
        /// </summary>
        public class StoreProceduces()
        {
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
            public const string EmployeeErrorExist = "Employee already exist in Database.";
            public const string EmployeeErrorNotExist = "Employee doesn't exist in database.";
            /// <summary>
            /// Area
            /// </summary>
            public const string AreaError = "Khong ton tai khu vuc co ID :";
        }
    }
}

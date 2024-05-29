namespace ApiLibrary.Constants
{
    public class SystemApiConst
    {
       public class Setting()
        {
            public const string StringContent = "application/json";
            public const string Bearer = "Bearer";
            public const string Token = "Token";
        }
        public class MessageError()
        {
            public const string Error = "Error occured";
            public const string StartTimeGreaterThanEndTime = "Start time must be less than end time";
        }
        public class Account()
        {
            public const string LoginUrl = "api/Account/login";
            public const string GetEmployees = "api/Account";    
            public const string RefreshToken = "api/Account/refresh-token";

        }
        public class WorkSchedule()
        {
            // Work Schedule
            public const string GetWorkSchedule = "api/WorkSchedule/";
        }
    }
}

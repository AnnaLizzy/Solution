namespace WebApplicationAPI.Service.Interfaces
{
    /// <summary>
    /// Account Service
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApiResult<string>> Authenticate(LoginDTO model);
        
    }
}

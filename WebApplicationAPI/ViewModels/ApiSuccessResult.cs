namespace WebApplicationAPI.ViewModels
{
    /// <summary>
    /// aspi success result class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        /// <summary>
        /// api success result
        /// </summary>
        /// <param name="resultObj"></param>
        /// <param name="message"></param>
        public ApiSuccessResult(T resultObj,string message)
        {
            IsSuccessed = true;
            Message = message;
            ResultObj = resultObj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="refreshToken"></param>
        /// <param name="message"></param>
        public ApiSuccessResult(T token, T refreshToken, string message)
        {
            IsSuccessed = true;
            Message = message;
            Token = token;
            RefreshToken = refreshToken;
            
        }
        /// <summary>
        /// api success result is true
        /// </summary>
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}

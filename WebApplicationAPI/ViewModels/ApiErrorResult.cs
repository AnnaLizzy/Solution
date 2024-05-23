namespace WebApplicationAPI.ViewModels
{
    /// <summary>
    /// result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiErrorResult<T> : ApiResult<T>
    {
        /// <summary>
        /// validation errors
        /// </summary>
        public string[]? ValidationErrors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ApiErrorResult()  {  }
        /// <summary>
        /// api error result message
        /// </summary>
        /// <param name="message"></param>
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
        /// <summary>
        /// api error result validation errors
        /// </summary>
        /// <param name="validationErrors"></param>
        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}

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
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
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

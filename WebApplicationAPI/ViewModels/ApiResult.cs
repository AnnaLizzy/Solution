namespace WebApplicationAPI.ViewModels
{
    /// <summary>
    /// api result class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// Successed or not
        /// </summary>
        public bool? IsSuccessed { get; set; }
        /// <summary>
        /// meassage
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// result object
        /// </summary>
        public T? ResultObj { get; set; }
    }
}

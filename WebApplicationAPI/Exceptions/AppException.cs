namespace WebApplicationAPI.Exceptions
{
    /// <summary>
    /// custom exception
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public AppException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public AppException(string message) : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

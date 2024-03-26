
namespace WebApplicationAPI.Exception
{
    public class AppException : IOException
    {
        public AppException()
        {
        }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, IOException innerException) : base(message, innerException)
        {
        }

       
    }
}

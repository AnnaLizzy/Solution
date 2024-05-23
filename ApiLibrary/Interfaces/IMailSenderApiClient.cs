using ApiLibrary.ViewModels;

namespace ApiLibrary.Interfaces
{
    public interface IMailSenderApiClient
    {
        Task<bool> SendMail(SendMailViewModel model);
    }
}

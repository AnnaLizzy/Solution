using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Service
{
    /// <summary>
    /// Mail sender
    /// </summary>
    public class MailSender(IOptions<MailSetting> mailSetting) : IEmailSender
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IOptions<MailSetting> emailSettings = mailSetting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>       
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient
            {
                Host = emailSettings.Value.SmtpServer ?? "",
                Port = emailSettings.Value.SmtpPort,
                EnableSsl = true,                
                Credentials = new NetworkCredential(emailSettings.Value.Mail, emailSettings.Value.Password),
                UseDefaultCredentials = false

            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings.Value.Mail ?? "", emailSettings.Value.DisplayName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
           
            try
            {               
                mailMessage.To.Add(email);              
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

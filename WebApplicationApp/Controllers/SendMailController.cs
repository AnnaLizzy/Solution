using ApiLibrary.ViewModels;

namespace WebApplicationApp.Controllers
{
    public class SendMailController(IMailSenderApiClient mailSender,IWebHostEnvironment webHost) : Controller
    {
        private readonly IMailSenderApiClient _sendMailApiClient = mailSender;
        private readonly IWebHostEnvironment webHostEnvironment = webHost;
        public IActionResult Index(SendMailViewModel request)
        { 
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Sign([FromForm] SendMailViewModel request)
        {
            var path = webHostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templete" + Path.DirectorySeparatorChar.ToString() + "MailTemp.html";
            var subject = "Test send mail";
            var body = System.IO.File.ReadAllText(path);
            await _sendMailApiClient.SendMail(new SendMailViewModel()
            {
                To = request.To,
                Subject = subject,
                Body = body
            });
            TempData["Success"] = "Send mail success";
            return RedirectToAction(nameof(Index));
        }
    }
}

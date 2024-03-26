using Microsoft.AspNetCore.Mvc;
using WebApplicationApp.ViewModels;

namespace WebApplicationApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Register()
        {
            RegisterRequest model = new();
            return View(model);
        }
    
    }
}

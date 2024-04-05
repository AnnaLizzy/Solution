using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApp.Controllers.Components
{
    public class ToastViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string message)
        {
            return View("Default", message);
        }
    }
}

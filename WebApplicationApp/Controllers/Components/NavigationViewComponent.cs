using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}

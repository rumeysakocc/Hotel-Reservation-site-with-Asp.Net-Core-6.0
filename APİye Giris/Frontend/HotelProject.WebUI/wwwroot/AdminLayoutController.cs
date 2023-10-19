using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.wwwroot
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}

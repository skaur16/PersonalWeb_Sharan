using Microsoft.AspNetCore.Mvc;

namespace PersonalWeb_Sharan.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}

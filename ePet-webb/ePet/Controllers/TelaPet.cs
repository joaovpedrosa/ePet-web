using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class TelaPet : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

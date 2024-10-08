using ePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class EntrarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string email, string senha)
        {
            Administrador administrador = new Administrador(email, senha);
            string resultado = administrador.logarUsuario();

            if (resultado == "logado")
            {
                return RedirectToAction("HomeADM", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email ou senha inválidos.";
                return View("Index"); 
            }
        }
    }
}

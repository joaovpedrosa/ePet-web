using ePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class CadastroController : Controller
    {
        [HttpPost]
        public IActionResult UsuarioCadastro(string nome, string email, string telefone, string endereco, string cpf, string senha)
        {
            Usuarios u = new Usuarios(nome, cpf, email, endereco, telefone, senha);
            TempData["msg"] = u.CadastrarUsuario();
            return RedirectToAction("Index","Home");
        }

        public IActionResult UsuarioDeletar(string cpf)
        {
            Usuarios u = new Usuarios(cpf, "");
            TempData["msg"] = u.DeletarUsuario();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UsuarioListar()
        {

            return View(Usuarios.ListarUsuario());
        }

        public IActionResult Usuario()
        {

            return View();
        }
    }
}

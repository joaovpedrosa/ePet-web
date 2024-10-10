using ePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class CadastroController : Controller
    {
        [HttpPost]
        public IActionResult UsuarioCadastro(string nome, string telefone, string cep, string cidade, string bairro, string rua, string complemento, string cpf, string email, string dataNasc, string senha, string isAdm)
        {
            Usuarios u = new Usuarios(nome, telefone, cep, cidade, bairro, rua, complemento, cpf, email, dataNasc, senha, "nao");
            TempData["msg"] = u.CadastrarUsuario();
            return RedirectToAction("Index", "Home");
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

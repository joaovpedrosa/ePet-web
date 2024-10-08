using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ePet.Controllers
{
    public class CadastroController : Controller
    {
        [HttpPost]
        public IActionResult UsuarioCadastro(string email, string senha, string cpf, string nome, string dataNasc, string cep, string cidade, string telefone, string bairro, string rua, string complemento, string isAdm)
        {
            Usuarios u = new Usuarios(email, senha, cpf, nome, dataNasc, cep, cidade, telefone, bairro, rua, complemento, isAdm);
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

using ePet.Models;
using ePet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class CadastroController : Controller
    {
        private readonly UserRepository userRepository = new UserRepository();
        [HttpPost]
        public IActionResult UsuarioCadastro(string nome, string telefone, string cep, string cidade, string bairro, string rua, string complemento, string cpf, string email, string dataNasc, string senha, string isAdm)
        {
            TempData["msg"] = userRepository.CadastrarUsuario(new Usuarios(nome, telefone, cep, cidade, bairro, rua, complemento, cpf, email, dataNasc, senha, "nao"));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UsuarioDeletar(string cpf)
        {
            
            TempData["msg"] = userRepository.DeletarUsuario(cpf);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UsuarioListar()
        {

            return View(userRepository.ListarUsuarios());
        }

        public IActionResult Usuario()
        {

            return View();
        }
    }
}

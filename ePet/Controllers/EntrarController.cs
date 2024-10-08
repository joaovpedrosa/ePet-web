using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ePet.Controllers
{
    public class EntrarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            // Criando objeto do usuário para conferir no banco se ele existe e se a senha bate
            Usuarios usuario = new Usuarios(email, senha);
            Usuarios usuarioAutenticado = usuario.logarUsuario(); // Agora retorna um objeto Usuarios

            // Armazenar a situação do login
            if (usuarioAutenticado != null)
            {
                // Verifica se o usuário é administrador
                if (usuarioAutenticado.IsAdm == "sim") // Aqui verificamos se o valor é "sim"
                {
                    // Criar uma sessão para armazenar os dados do usuário
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuarioAutenticado));
                    return RedirectToAction("HomeADM", "Home"); // Redireciona para HomeADM
                }
                else
                {
                    // Criar uma sessão para armazenar os dados do usuário
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuarioAutenticado));
                    return RedirectToAction("Index", "Home"); // Redireciona para Index
                }
            }
            else
            {
                // Se o login falhar, retorna uma mensagem de erro
                ModelState.AddModelError("", "Usuário ou senha inválidos.");
                return RedirectToAction("Entrar", "Home"); // Redireciona para Index em caso de erro
            }
        }

    }
}


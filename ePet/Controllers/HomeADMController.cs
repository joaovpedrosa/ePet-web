using ePet.Models;
using ePet.Repository;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

namespace ePet.Controllers
{
    public class HomeADMController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult CadastroPet()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult PesquisaDisk()
        {
            return View();
        }

        public IActionResult PesquisaUsuario()
        {
            UserRepository u = new UserRepository();
            List<Usuarios> lista = u.ListarUsuarios();

            return View(lista);
        }

        public IActionResult PesquisaPet()
        {
            if(ViewBag.animal == null)
            {
                ViewBag.animal = new Animais(null, null, null, null, null, null, null,null,null,null,null);
            }
            return View();
        }

        public IActionResult Alterar()
        {
            return View();
        }


        //MAnipulação
        [HttpPost]
        public IActionResult CadastrarAnimal(string codigo_animal, string t_animal, string status, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento, string sexo,IFormCollection form)
        {
            IFormFile imagem;
            imagem = form.Files.First();
            Animais animal = new Animais( codigo_animal,  t_animal,  status,  nome,  idade,  castracao, raca,  porte,  peso,comportamento, sexo);
            string msg = animal.CadastrarAnimal();
            if (msg == "Inserido com sucesso!")
            {
                return RedirectToAction("HomeADM", "Home");
            }
            else
            {
                return RedirectToAction("CadastroPet");
            }
        }

        [HttpPost]
        public IActionResult DeletarAnimal(string cod_animal)
        {
            Animais animal = new Animais(cod_animal);
            string msg = animal.DeletarAnimal();
            if (msg == "Excluido com sucesso!")
            {
                return RedirectToAction("HomeADM", "Home");
            }
            else
            {
                return RedirectToAction("Deletar");
            }
        }

        [HttpPost]
        public IActionResult BuscarUsuario(string cod_usuario)
        {
            UserRepository userRepository = new UserRepository();
            
            var user = userRepository.BuscarUsuario(cod_usuario);
            ViewBag.user = user;
            return View("PesquisaUsuario");
        }
    
}
}

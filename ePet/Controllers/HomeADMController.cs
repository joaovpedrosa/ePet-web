using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

namespace ePet.Controllers
{
    public class HomeADMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
            if (ViewBag.user == null)
            {
                ViewBag.user = new Usuarios(null, null, null, null, null, null, null, null, null, null, null, null);
            }
            return View();
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

        //[HttpPost]
        //public IActionResult AlterarAnimal(string nome, string T_sanguineo, string autoridade_responsavel, string status, string cod_animal)
        //    {
        //    Animais animal = new Animais(cod_animal, null, T_sanguineo, null, status, autoridade_responsavel, nome);
        //    animal.AlterarAnimal(cod_animal);
        //    return RedirectToAction("HomeADM", "Home");
        //}

        //[HttpPost]
        //public IActionResult ListarAnimal(string cod_animal)
        //{
        //    Animais animal = new Animais(null,null,null,null,null,null,null);
        //    animal = animal.BuscarAnimal(cod_animal);
        //    ViewBag.animal = animal;
        //    return View("PesquisaPet");
        //}
        [HttpPost]
        public IActionResult BuscarUsuario(string cod_usuario)
        {
            Usuarios user = new Usuarios(null, null, null, null, null, null, null, null, null, null, null, null);
            user = user.BuscarUsuario(cod_usuario);
            ViewBag.user = user;
            return View("PesquisaUsuario");
        }
    
}
}

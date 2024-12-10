using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using ePet.Repository;
using Microsoft.EntityFrameworkCore;


namespace ePet.Controllers
{
    public class HomeController : Controller
    {
        private PetRepository animaR = new PetRepository();
        private AdocaoRepository adocaoRepository = new AdocaoRepository(); 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Adotar()
        {
            System.Diagnostics.Debug.WriteLine("Get method called");
            return View();
        }

        [HttpPost]
        public IActionResult Adotar(Adocao adocao)
        {

            var mensagem = adocaoRepository.AdicionarAdocao(adocao);
            ViewBag.Mensagem = mensagem;
            return View();
        }


        //linkar na nav-bar o adote
        public ActionResult Adote()
        {
            PetRepository u = new PetRepository();
            List<Animais> lista = u.ListarAnimais();

            return View(lista);
        }


        //linkar na nav-bar o home
        public ActionResult Home()
        {
            return View();
        }

        //linkar na nav-bar o disk
        public ActionResult Disk()
        {
            return View();
        }

        public IActionResult PesquisaPet()
        {
            PetRepository u = new PetRepository();
            List<Animais> lista = u.ListarAnimais();

            return View(lista);
        }

        public IActionResult Alterar()
        {
            return View();
        }

        //linkar na nav-bar o cadastro
        public ActionResult Cadastro()
        {
            return View();
        }


        //linkar na nav-bar o homeADM
        public IActionResult HomeADM()
        {
            return View();
        }

        //linkar o entrar 
        public ActionResult Entrar()
        {
            return View();
        }

        //linkar tela do perfil do pet com a tela adoção
        public ActionResult TelaPet(string codigo_animal)
        {
            if (string.IsNullOrEmpty(codigo_animal))
            {
                TempData["MensagemErro"] = "Código do animal não fornecido.";
                return RedirectToAction("Adote"); // Redireciona para a lista se o código for inválido
            }

            var animal = animaR.GetPet(codigo_animal);

            if (animal == null)
            {
                TempData["MensagemErro"] = "Animal não encontrado.";
                return RedirectToAction("Adote"); // Redireciona para a lista se o animal não for encontrado
            }

            return View(animal); // Retorna o modelo do animal para a view
        }

        //linkar tela apadrinhamento
        public ActionResult Apadrinhe()
        {
            return View();
        }

    }
}

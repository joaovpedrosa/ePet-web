using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using ePet.Repository;


namespace ePet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //linkar na nav-bar o adote
        public ActionResult Adote()
        {
            return View();
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

        //linkar tela do perfil do pet com a tela ado��o
        public ActionResult TelaPet()
        {
            return View();
        }

        //linkar tela apadrinhamento
        public ActionResult Apadrinhe()
        {
            return View();
        }

    }
}

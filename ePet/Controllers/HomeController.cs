using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;


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


        //linkar tela do perfil do pet com a tela adoção
        public ActionResult TelaPet()
        {
            return View();
        }


        //Logar usuário
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            //CRIANDO OBJETO DO USUÁRIO PARA CONFERIR NO BANCO SE ELE EXISTE E SE A SENHA BATE
            Usuarios usuario = new Usuarios(email, senha);
            string loginEstado = usuario.logarUsuario();
            TempData["SituacaoLogin"] = loginEstado;

            //CASO ELE CONSIGA LOGAR, SER DIRECIONADO PARA A PÁGINA INICIAL
            if (loginEstado == "logado")
            {
                //Criar uma sessão para armazenar os dados do usuário
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                return Redirect("/Home/Adote");
            }


            else
            {
                    Administrador adm = new Administrador(email, senha);
                string loginAdm = adm.logarUsuario();
                if (loginAdm == "logado")
                {
                    //Criar uma sessão para armazenar os dados do usuário
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return Redirect("/Home/HomeADM");
                }
                else
                {
                    return Redirect("/Home/Index");
                }
                
            }
        }

        //Logar usuário
        [HttpPost]
        public IActionResult LoginADM(string email, string senha)
        {
            //CRIANDO OBJETO DO USUÁRIO PARA CONFERIR NO BANCO SE ELE EXISTE E SE A SENHA BATE
            Administrador usuario = new Administrador(email, senha);
            string loginEstado = usuario.logarUsuario();
            TempData["SituacaoLogin"] = loginEstado;

            //CASO ELE CONSIGA LOGAR, SER DIRECIONADO PARA A PÁGINA INICIAL
            if (loginEstado == "logado")
            {
                //Criar uma sessão para armazenar os dados do usuário
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                return Redirect("/Home/HomeADM");
            }


            else
            {
                return Redirect("/Home/Index"); ;
            }
        }

        [HttpPost]
        public IActionResult Ocorrencia(string email, string senha)
        {
            return null;
        }


            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

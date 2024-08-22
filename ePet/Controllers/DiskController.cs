using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ePet.Controllers
{
    public class DiskController : Controller
    {
        public IActionResult OcorrenciaCadastro(string cod_ocorrencia, string data, string descricao, string lugar, string cpf, string numero_id)
        {
            Ocorrencias ocorrencia = new Ocorrencias(cod_ocorrencia, data, descricao, lugar, cpf, numero_id);
            TempData["msg"] = ocorrencia.CadastrarOcorrencia();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult OcorrenciaBuscar(string cod_ocorrencia)
        {
            return View(Ocorrencias.BuscarOcorrencia);
        }

        public IActionResult OcorrenciaListar()
        {
            return View(Ocorrencias.ListarOcorrencia);
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
        public ActionResult HomeADM()
        {
            return View();
        }
    }
}

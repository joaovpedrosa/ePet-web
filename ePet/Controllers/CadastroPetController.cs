using ePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    public class CadastroPetController : Controller
    {
        [HttpPost]
        public IActionResult CadastroAnimal(string codigo_animal, string t_animal, string t_sanguinio,string codigo_dono, string status, string autoridade_responsavel, string nome)
        {
            Animais animal = new Animais(codigo_animal,t_animal,t_sanguinio,codigo_dono, status, autoridade_responsavel, nome);
            return RedirectToAction("Salvar");
        }

        public IActionResult DeletarAnimal(string codigo_animal)
        {
            Animais animal = new Animais(codigo_animal);
            TempData["msg"] = animal.DeletarAnimal();
            return RedirectToAction("Listar");
        }

        public IActionResult ListarAnimal()
        {
            return View(Animais.ListarAnimal());
        }

        public IActionResult Animal()
        {
            return View();
        }
    }
}

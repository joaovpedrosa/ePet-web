﻿using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ePet.Controllers
{
    public class CadastroPetController : Controller
    {
        [HttpPost]
        public IActionResult CadastroAnimal(string codigo_animal, string t_animal, string status, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento, string sexo)
        {
            Animais animal = new Animais(codigo_animal, t_animal, status, nome, idade, castracao, raca, porte, peso, comportamento, sexo);
            animal.CadastrarAnimal();
            return RedirectToAction("Index", "Home");
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

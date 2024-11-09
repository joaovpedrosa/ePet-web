using ePet.Models;
using ePet.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MySqlX.XDevAPI.Common;

namespace ePet.Controllers
{
    public class CadastroPetController : Controller
    {
        [HttpPost]
        public IActionResult CadastroAnimal(string codigo_animal, string t_animal, string status, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento, string sexo)
        {
            try
            {
                //aqui eu pego a imagem enviada no corpo do request
                foreach (IFormFile arq in Request.Form.Files)
                {
                    //se o arquivo for do tipo imagem, eu deixo salvar, caso for de outro tipo, ele retorna um erro, ja que a imagem será null...
                    if (arq.ContentType.Contains("image"))


                    {
                        //crio um arquivo de memoria para a imagem
                        MemoryStream memoryStream = new MemoryStream();
                        //transfiro a imagem para essa memory
                        arq.CopyTo(memoryStream);
                        //depois deixo em array de bytes
                        byte[] imagem = memoryStream.ToArray();

                        //crio um jogo que sera adicionado com os campos
                        Animais animal = new Animais(codigo_animal, t_animal, status, nome, idade, castracao, raca, porte, peso, comportamento, sexo);
                        animal.ArrayBytes = imagem;
                        PetRepository pet = new PetRepository();
                        pet.CadastrarAnimal(animal);
                    }
                    else
                    {
                        View("ERRO AO CADASTRAR ANIMAL, PQ NÃO TEM UMA IMAGEM");
                    }
                }
            }
            catch (Exception ex)
            {
                View(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeletarAnimal(string codigo_animal)
        {
            Animais animal = new Animais(codigo_animal);
            //TempData["msg"] = animal.DeletarAnimal();
            return RedirectToAction("Listar");
        }

        public IActionResult ListarAnimal()
        {
            return View();
        }

        public IActionResult Animal()
        {
            return View();
        }
    }
}

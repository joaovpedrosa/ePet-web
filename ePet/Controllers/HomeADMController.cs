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
        private readonly DenunciarRepository denunciaRepositorio = new DenunciarRepository();
        private readonly PetRepository petRepository = new PetRepository();
        private readonly UserRepository _userRepository;

        // Construtor do controlador
        public HomeADMController(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IActionResult CadastroPet()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditarUsuario(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return BadRequest("CPF não fornecido.");
            }

            var usuario = _userRepository.BuscarUsuario(cpf);
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso não encontre o usuário
            }

            return View(usuario);
        }


        // Action para atualizar os dados do usuário
        [HttpPost]
        public IActionResult AtualizarUsuario(Usuarios usuario)
        {
            // Aqui você pode chamar seu repositório para atualizar os dados no banco
            var resultado = _userRepository.AtualizarUsuario(usuario);
            if (resultado == "Atualizado com sucesso!")
            {
                return RedirectToAction("PesquisaUsuario"); // Redireciona para a lista de usuários
            }
            else
            {
                // Exibir uma mensagem de erro se a atualização falhar
                ViewBag.Erro = "Erro ao atualizar usuário.";
                return View(usuario);
            }
        }

        public IActionResult Denuncia()
        {
            DenunciarRepository u = new DenunciarRepository();
            List<Denunciar> lista = u.ListaDenuncia();

            return View(lista); 
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

        public IActionResult DeletarUsuario(string cpf)
        {
            UserRepository userRepository = new UserRepository();
            string mensagem = userRepository.DeletarUsuario(cpf);

            // Aqui você pode definir o que fazer com a mensagem de sucesso ou erro
            // Exemplo: retornar para a página de usuários ou exibir uma mensagem
            if (mensagem == "Excluído com sucesso!")
            {
                return RedirectToAction("PesquisaUsuario"); // Ou para a página que lista os usuários
            }
            else
            {
                ViewBag.Erro = mensagem; // Exibe a mensagem de erro
                return View("PesquisaUsuario"); // Retorna à página de pesquisa de usuários
            }
        }

        public IActionResult DeletarDenuncia(string codigoDenun)
        {
            DenunciarRepository denunciarRepository = new DenunciarRepository();  
            string mensagem = denunciarRepository.DeletarDenuncia(codigoDenun);  

            if (mensagem == "Excluído com sucesso!")
            {
                return RedirectToAction("Denuncia");
            }
            else
            {
                ViewBag.Erro = mensagem;
                return View("Denuncia");
            }
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


        //MAnipulação
        //MAnipulação
        [HttpPost]
        public IActionResult CadastrarAnimal(string codigo_animal, string t_animal, string status, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento, string sexo, byte[] arraybyte, IFormCollection form)
        {
            IFormFile imagem;
            imagem = form.Files.First();
            Animais animal = new Animais(codigo_animal, t_animal, status, nome, idade, castracao, raca, porte, peso, comportamento, sexo,arraybyte);

            string msg = petRepository.CadastrarAnimal(animal);
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
        public IActionResult DeletarAnimal(string codAnimal)
        {
            Animais animal = new Animais(codAnimal);
            string msg = petRepository.DeletarAnimal(codAnimal);
            if (msg == "Excluido com sucesso!")
            {
                return RedirectToAction("PesquisaPet");
            }
            else
            {
                return RedirectToAction("PesquisaPet");
            }
        }
        //[HttpGet]
        //public IActionResult EditarPet(string codAnimal)
        //{
        //    if (string.IsNullOrEmpty(codAnimal))
        //    {
        //        return BadRequest("Codigo do animal não fornecido.");
        //    }

        //    var animal = PetRepository.
        //    if (animal == null)
        //    {
        //        return NotFound(); // Retorna 404 caso não encontre o Animal
        //    }

        //    return View(animal);
        //}

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

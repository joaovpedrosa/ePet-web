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
        private readonly AdocaoRepository adocaoRepository = new AdocaoRepository();
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

        [HttpGet]
        public IActionResult PesquisaPet(string searchTerm)
        {
            List<Animais> lista = petRepository.ListarAnimais();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                lista = lista.Where(a =>
                    a.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.Raca.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.T_Animal.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["SearchTerm"] = searchTerm;
            return View(lista);
        }

        [HttpGet]
        public IActionResult PesquisaUsuario(string searchTerm)
        {
            UserRepository userRepository = new UserRepository();
            List<Usuarios> listaUsuarios;

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Se não houver termo de busca, lista todos os usuários
                listaUsuarios = userRepository.ListarUsuarios();
            }
            else
            {
                // Filtra os usuários com base no termo de busca
                listaUsuarios = userRepository.ListarUsuarios()
                    .Where(u =>
                        u.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        u.Cpf.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        u.Cidade.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewData["SearchTerm"] = searchTerm; // Mantém o termo no campo de busca
            return View(listaUsuarios); // Retorna a lista filtrada ou completa para a View
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

        public IActionResult Adocao()
        {
            AdocaoRepository u = new AdocaoRepository();
            List<Adocao> lista = u.ListaAdocao();

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

        public IActionResult DeletarAdocao(string codigoAdo)
        {
            AdocaoRepository adocaoRepository = new AdocaoRepository();
            string mensagem = adocaoRepository.DeletarAdocao(codigoAdo);

            if (mensagem == "Excluído com sucesso!")
            {
                return RedirectToAction("Adocao");
            }
            else
            {
                ViewBag.Erro = mensagem;
                return View("Adocao");
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
        [HttpGet]
        public IActionResult EditarPet(string codAnimal)
        {
            if (string.IsNullOrEmpty(codAnimal))
            {
                return BadRequest("Codigo do animal não fornecido.");
            }

            var animal = petRepository.BuscarAnimal(codAnimal);
            if (animal == null)
            {
                return NotFound(); // Retorna 404 caso não encontre o Animal
            }

            return View(animal);
        }

        [HttpPost]
        public IActionResult AtualizarAnimal(Animais animais)
        {
            // Aqui você pode chamar seu repositório para atualizar os dados no banco
            var resultado = petRepository.AtualizarAnimal(animais);
            if (resultado == "Atualizado com sucesso!")
            {
                return RedirectToAction("PesquisaPet"); // Redireciona para a lista de usuários
            }
            else
            {
                // Exibir uma mensagem de erro se a atualização falhar
                ViewBag.Erro = "Erro ao atualizar usuário.";
                return View(animais);
            }
        }


    }
}

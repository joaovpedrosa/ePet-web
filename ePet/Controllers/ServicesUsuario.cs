using ePet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesUsuario : ControllerBase
    {
        [HttpGet("Teste")]
        public IActionResult Index([FromBody] Usuarios u)
        {
            u = new Usuarios(u.Nome, u.Email, u.Telefone, u.Endereco, u.Cpf, u.Senha);

            string resposta = u.CadastrarUsuario();

            return Ok(resposta);
        }


    }
}

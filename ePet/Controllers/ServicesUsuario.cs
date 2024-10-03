using ePet.Models;
using K4os.Compression.LZ4.Internal;
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
            u = new Usuarios(u.Email, u.Senha, u.Cpf, u.Nome, u.DataNasc, u.Cep, u.Cidade, u.Telefone, u.Bairro, u.Rua, u.Complemento);

            string resposta = u.CadastrarUsuario();

            return Ok(resposta);
        }


    }
}

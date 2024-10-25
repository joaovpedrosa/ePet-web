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
            u = new Usuarios(u.Nome, u.Telefone, u.Cep, u.Cidade, u.Bairro, u.Rua, u.Complemento, u.Cpf, u.Email, u.DataNasc,  u.Senha, u.IsAdm);

            string resposta = u.CadastrarUsuario();

            return Ok(resposta);
        }


    }
}

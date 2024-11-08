using ePet.Models;
using ePet.Repository;
using K4os.Compression.LZ4.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesUsuario : ControllerBase
    {
        private UserRepository userRepository = new UserRepository();

        [HttpPost("Teste")]
        public IActionResult Index([FromBody] Usuarios u)
        {   
            return Ok(new { mensagem = userRepository.CadastrarUsuario(u)});
        }


    }
}

using ePet.Models;
using ePet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ePet.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceDenunciar : Controller
    {
        private DenunciarRepository denunciarRepository = new DenunciarRepository();

        [HttpPost("Denunciar")]
        public IActionResult Denunciar([FromBody] Denunciar d)
        {
            return Ok(new { mensagem = denunciarRepository.DenunciarAbandono(d) });
        }
    }
}

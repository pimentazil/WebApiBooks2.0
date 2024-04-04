using Microsoft.AspNetCore.Mvc;
using WebApiBooks.Repository;
using WebApiBooks.Application.Model;
using WebApiBooks.Application.Service;
using Microsoft.AspNetCore.Authorization;


namespace WebApiBooks.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _ctx;

        public UsuarioController(Context context)
        {
            _ctx = context;
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult CadastrarUsuario([FromBody] UsuarioRequest request)
        {
            var cadastroService = new UsuarioService(_ctx);
            var sucesso = cadastroService.CadastrarUsuario(request);

            if (sucesso == null)
            {
                return BadRequest(sucesso);
            }
            else
            {
                return Ok(sucesso);
            }
        }
    }
}

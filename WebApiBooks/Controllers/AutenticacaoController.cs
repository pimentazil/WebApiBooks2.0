using Microsoft.AspNetCore.Mvc;
using WebApiBooks.Application.Model;
using WebApiBooks.Repository;
using WebApiBooks.Application.Service;


namespace WebApiBooks.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly Context _ctx;
        public AutenticacaoController(Context ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request)
        {
            var autenticacao = new AutenticacaoService(_ctx);
            var token = autenticacao.Autenticar(request);

            if (token == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}

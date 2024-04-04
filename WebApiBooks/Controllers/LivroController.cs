using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiBooks.Application.Model;
using WebApiBooks.Application.Service;
using WebApiBooks.Repository;

namespace WebApiBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly Context _ctx;

        public LivroController(Context context)
        {
            _ctx = context;
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult adicionarLivro([FromBody] LivroRequest request)
        {
            
            try
            {
                var livroService = new LivroService(_ctx);
                var sucesso = livroService.adicionarLivro(request);

                return Ok(sucesso); 
            }
        catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Ocorreu um erro ao processar a solicitação.", detalhes = ex.Message });

            }
        }

        [HttpGet]
        public IActionResult obterLivros()
        {
            var livroService = new LivroService(_ctx);
            return Ok(livroService.obterLivros());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult obterLivro(int id)
        {
            var livroService = new LivroService(_ctx);
            return Ok(livroService.obterLivro(id));
        }
    

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult deletarLivro(int id)
        {
            var livroService = new LivroService(_ctx);
            var sucesso = livroService.deletarLivro(id);

            if (sucesso)
            {
                return Ok("Livro deletado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao deletar o livro. Verifique se o ID é válido.");
            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult atualizarLivro(int id, [FromBody] LivroRequest request)
        {
            var livroService = new LivroService(_ctx);
            var sucesso = livroService.atualizarLivro(id, request);

            if (sucesso)
            {
                return Ok("Livro atualizado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao atualizar o livro. Verifique se o ID é válido.");
            }
        }
    }
}
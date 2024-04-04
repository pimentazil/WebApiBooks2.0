using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiBooks.Application.Model;
using WebApiBooks.Repository;
using WebApiBooks.Repository.Models;

namespace WebApiBooks.Application.Service
{
    public class LivroService
    {
        private readonly Context _ctx;

        public LivroService(Context context)
        {
            _ctx = context;
        }

        public bool adicionarLivro(LivroRequest request)
        {
            try
            {
                var livro = new TabLivro()
                {
                    titulo = request.titulo,
                    autor = request.autor,
                    preco = request.preco,
                    dataLancamento = request.dataLancamento,
                };

                _ctx.tabLivro.Add(livro);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TabLivro> obterLivros()
        {
            try
            {
                List<TabLivro> doacao = new List<TabLivro>();
                var doacoes = _ctx.tabLivro.ToList();
                var tipoProduto = _ctx.tabLivro.ToList();
                var usuario = _ctx.tabUsuario.ToList();
                foreach (var item in doacoes)
                {

                    doacao.Add(new TabLivro
                    {
                        id = item.id,
                        titulo = item.titulo,
                        autor = item.autor,
                        preco = item.preco,
                        dataLancamento = item.dataLancamento,
                    });
                }
                return doacao;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TabLivro obterLivro(int id)
        {
            try
            {
                return _ctx.tabLivro.FirstOrDefault(x => x.id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deletarLivro(int livroId)
        {
            try
            {
                var livro = _ctx.tabLivro.Find(livroId);

                if (livro != null)
                {
                    _ctx.tabLivro.Remove(livro);
                    _ctx.SaveChanges();
                    return true;
                }

                return false; // Livro não encontrado
            }
            catch (Exception ex)
            {
                // Lide com a exceção conforme necessário, por exemplo, registre ou retorne detalhes do erro.
                return false;
            }
        }

        public bool atualizarLivro(int livroId, LivroRequest request)
        {
            try
            {
                var livro = _ctx.tabLivro.Find(livroId);

                if (livro != null)
                {
                    livro.titulo = request.titulo;
                    livro.autor = request.autor;
                    livro.preco = request.preco;
                    livro.dataLancamento = request.dataLancamento;

                    _ctx.SaveChanges();
                    return true;
                }

                return false; // Livro não encontrado
            }
            catch (Exception ex)
            {
                // Lide com a exceção conforme necessário, por exemplo, registre ou retorne detalhes do erro.
                return false;
            }
        }

    }
}

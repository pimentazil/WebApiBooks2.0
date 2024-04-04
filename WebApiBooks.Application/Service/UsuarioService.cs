using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiBooks.Repository;
using WebApiBooks.Repository.Models;
using WebApiBooks.Application.Model;

namespace WebApiBooks.Application.Service
{
    public class UsuarioService
    {
        private readonly Context _ctx;

        public UsuarioService(Context context)
        {
            _ctx = context;
        }

        public bool CadastrarUsuario(UsuarioRequest request)
        {
            try
            {
                var usuario = new TabUsuario()
                {
                    nome = request.nome,
                    senha = request.senha,
                };

                _ctx.tabUsuario.Add(usuario);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}

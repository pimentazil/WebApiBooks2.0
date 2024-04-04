using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiBooks.Repository;
using WebApiBooks.Repository.Models;
using WebApiBooks;
using WebApiBooks.Application.Model;

namespace WebApiBooks.Application.Service
{
    public class AutenticacaoService
    {
        private readonly Context _ctx;
        public AutenticacaoService(Context ctx)
        {
            _ctx = ctx;
        }

        public LoginResponse Autenticar(AutenticacaoRequest request)
        {
            var usuario = _ctx.tabUsuario.FirstOrDefault(x => x.nome == request.nome && x.senha == request.senha);
            if (usuario == null)
            {
                return null;
            }
            if (usuario.id == 0)
            {
                return null;
            }
            _ctx.tabUsuario.Update(usuario);
            _ctx.SaveChanges();
            return new LoginResponse
            {
                token = GerarTokenJwt(usuario),
                tipo = Convert.ToInt32(usuario.id),
                codigo = usuario.id,
                nome = usuario.nome,
            };
        }

        private string GerarTokenJwt(TabUsuario usuario)
        {
            var issuer = "var";
            var audience = "var";
            var key = "c013239a-5e89-4749-b0bb-07fe4d21710d";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(100), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}

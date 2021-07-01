using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using Recuperacao.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Repositorios
{
    public class ContaRepository : IConta
    {
        private readonly RecuperacaoContext _context;

        public ContaRepository(RecuperacaoContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario Register(string nome, string email, string senha, string tipo, string cargo, string cpf)
        {
            Usuario usuario = new Usuario() { Nome = nome, Email = email, Senha = senha, TipoUsuario = tipo, Cargo = cargo, CPF = cpf };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}


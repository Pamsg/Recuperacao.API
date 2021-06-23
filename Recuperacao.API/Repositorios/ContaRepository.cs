using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Repositorios
{
    public class ContaRepository : IConta
    {
        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario Register(string nome, string email, string senha, string tipo)
        {
            throw new NotImplementedException();
        }
    }
}

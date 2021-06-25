using Recuperacao.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Interface
{
    interface IConta
    {
        Usuario Login(string email, string senha);

        Usuario Register(string nome, string email, string senha, string tipo, string cargo, string cpf);
    }
}

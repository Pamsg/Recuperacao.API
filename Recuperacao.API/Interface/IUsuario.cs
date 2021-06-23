using Recuperacao.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Interface
{
    interface IUsuario
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorNome(string nome);
        void Adicionar(Usuario usuario);
        void Deletar(Guid id);
        void Editar(Usuario usuario);
    }
}

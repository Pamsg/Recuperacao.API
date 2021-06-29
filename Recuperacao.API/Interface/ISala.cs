using Recuperacao.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Interface
{
    interface ISala
    {
        List<Sala> Listar();
        Sala BuscarPorId(Guid id);
        Sala BuscarPorAndar(string andar);
        void Adicionar(Sala sala);
        void Deletar(Guid id);
        void Editar(Sala sala);
    }
}

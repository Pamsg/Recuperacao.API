using Recuperacao.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Interface
{
    interface IEquipamento
    {
        List<Equipamento> Listar();
        Equipamento BuscarPorId(Guid id);
        Equipamento BuscarPorNome(string nome);
        void Adicionar(Equipamento equipamento);
        void Deletar(Guid id);
        void Editar(Equipamento equipamento);
    }
}

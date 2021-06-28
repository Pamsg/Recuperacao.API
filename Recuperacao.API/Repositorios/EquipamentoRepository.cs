using Recuperacao.Api.Contexts;
using Recuperacao.Api.Repositorios;
using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Repositorios
{

    public class EquipamentoRepository : IEquipamento
    {

        private readonly RecuperacaoContext _ctx;

        public EquipamentoRepository()
        {
            _ctx = new RecuperacaoContext();
        }
        public void Adicionar(Equipamento equipamento)
        {
            try
            {
                _ctx.Equipamentos.Add(equipamento);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
              }
        }

        public Equipamento BuscarPorId(Guid id)
        {
            try
            {
                Equipamento equipamento = _ctx.Equipamentos.FirstOrDefault(c => c.Id == id);
                return equipamento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Equipamento BuscarPorTipo(string tipo)
        {
            try
            {
                Equipamento equipamento = _ctx.Equipamentos.FirstOrDefault(c => c.Tipo == tipo);
                return equipamento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }  
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Equipamento equipamento)
        {
            throw new NotImplementedException();
        }

        public List<Equipamento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

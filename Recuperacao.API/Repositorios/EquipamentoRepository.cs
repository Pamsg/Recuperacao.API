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

        List<Sala> BuscarPorTipo(string tipo)
        {
            try
            {
                return _ctx.Equipamentos.Where(c => c.Andar.Contains(tipo)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Sala BuscarPorId(Guid id)
        {
            try
            {
                Sala sala = _ctx.Equipamentos.FirstOrDefault(c => c.Id == id);
                return sala;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Sala equipamentoTemp = BuscarPorId(id);

                if (equipamentoTemp == null)
                    throw new Exception("Equipamento não encontrado");


                _ctx.Equipamentos.Remove(equipamentoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Editar(Equipamento equipamento)
        {
            try
            {
                Equipamento equipamentoTemp = BuscarPorId(equipamento.Id);

                if (equipamentoTemp == null)
                    throw new Exception("Equipamento não encontrada");

                equipamentoTemp.Tipo = equipamento.Tipo;

                _ctx.Equipamentos.Update(equipamentoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<equipamento> Listar()
        {
            throw new NotImplementedException();
        }

       
    }
}

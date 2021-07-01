using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using Recuperacao.Context;
using System;
using System.Collections.Generic;
using System.Linq;


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
            try
            {
                Equipamento equipamentoTemp = BuscarPorId(id);

                if (equipamentoTemp == null)
                    throw new Exception("Equipamento não encontrada");


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

        public List<Equipamento> Listar()
        {
            try
            {
                List<Equipamento> equipamentos = _ctx.Equipamentos.ToList();
                return equipamentos;
            }
            catch (Exception ex) 
            {

                throw new Exception(ex.Message); 
            }
        }
    }
}

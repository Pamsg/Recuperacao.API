using Recuperacao.Api.Contexts;
using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Repositorios
{
    public class SalaRepository : ISala
    {
        private readonly RecuperacaoContext _ctx;

        public SalaRepository()
        {
            _ctx = new RecuperacaoContext();
        }

        public void Adicionar(Sala sala)
        {
            try
            {
                _ctx.Salas.Add(sala);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Sala BuscarPorAndar(string andar)
        {
            try
            {
                Sala sala = _ctx.Salas.FirstOrDefault(c => c.Andar == andar);
                return sala;
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
                Sala sala = _ctx.Salas.FirstOrDefault(c => c.Id == id);
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
                Sala salaTemp = BuscarPorId(id);

                if (salaTemp == null)
                    throw new Exception("Sala não encontrada");


                _ctx.Salas.Remove(salaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
            public void Editar(Sala sala)
            {
                try
                {
                    Sala salaTemp = BuscarPorId(sala.Id);

                    if (salaTemp == null)
                        throw new Exception("Sala não encontrada");

                    salaTemp.Andar = sala.Andar;

                    _ctx.Salas.Update(salaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            public List<Sala> Listar()
            {
            try
            {
                List<Sala> salas = _ctx.Salas.ToList();
                return salas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            }

      
    }
    }


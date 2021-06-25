﻿using Recuperacao.Api.Contexts;

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
                _ctx.Equipamentos.Add(sala);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        List<Sala> BuscarPorAndar(string andar)
        {
            try
            {
                return _ctx.Equipamentos.Where(c => c.Andar.Contains(andar)).ToList();
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
                Sala salaTemp = BuscarPorId(id);

                if (salaTemp == null)
                    throw new Exception("Sala não encontrada");


                _ctx.Equipamentos.Remove(salaTemp);
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

                    _ctx.Equipamentos.Update(salaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            public List<Sala> Listar()
            {
                throw new NotImplementedException();
            }

        List<Sala> ISala.BuscarPorAndar(string andar)
        {
            throw new NotImplementedException();
        }
    }
    }


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recuperacao.API.Domains;
using Recuperacao.API.Interface;
using Recuperacao.API.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamento _equipamentoRepository;

        public EquipamentoController()
        {
            _equipamentoRepository = new EquipamentoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var equipamentos = _equipamentoRepository.Listar();

                if (equipamentos.Count == 0)
                    return NoContent();

                return Ok(equipamentos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Equipamento equipamento = _equipamentoRepository.BuscarPorId(id);

                if (equipamento == null)
                    return NotFound();

                return Ok(equipamento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("tipo/{tipo}")]
        public IActionResult Get(string tipo)
        {
            try
            {
                Equipamento equipamento = _equipamentoRepository.BuscarPorTipo(tipo);

                if (tipo == null)
                    return NotFound();

                return Ok(tipo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Equipamento equipamento)
        {
            try
            {
                _equipamentoRepository.Adicionar(equipamento);

                return Ok(equipamento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Equipamento equipamento)
        {
            try
            {
                var equipamentoTemp = _equipamentoRepository.BuscarPorId(id);

                if (equipamentoTemp == null)
                    return NotFound();

                equipamento.Id = id;
                _equipamentoRepository.Editar(equipamento);

                return Ok(equipamento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _equipamentoRepository.Deletar(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

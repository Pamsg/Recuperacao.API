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
    public class SalaController : ControllerBase
    {
        private readonly ISala _salaRepository;

        public SalaController()
        {
            _salaRepository = new SalaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var salas = _salaRepository.Listar();

                if (salas.Count == 0)
                    return NoContent();

                return Ok(salas);
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
                Sala sala = _salaRepository.BuscarPorId(id);

                if (sala == null)
                    return NotFound();

                return Ok(sala);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }       
        }
        [HttpGet("andar/{andar}")]
        public IActionResult Get(string andar)
        {
            try
            {
                Sala sala = _salaRepository.BuscarPorAndar(andar);

                if (andar == null)
                    return NotFound();

                return Ok(andar);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Sala sala)
        {
            try
            {
                _salaRepository.Adicionar(sala);

                return Ok(sala);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Sala sala)
        {
            try
            {
                var salaTemp = _salaRepository.BuscarPorId(id);

                if (salaTemp == null)
                    return NotFound();

                sala.Id = id;
                _salaRepository.Editar(sala);

                return Ok(sala);
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
                _salaRepository.Deletar(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

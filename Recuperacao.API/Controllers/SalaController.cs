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
        public List<Sala> Get()
        {
            return _salaRepository.Listar();
        }

        [HttpGet("{id}")]
        public Sala Get(Guid id)
        {
            return _salaRepository.BuscarPorId(id);       
        }

        [HttpPost]
        public void Post(Sala sala)
        {
             _salaRepository.Adicionar(sala);
        }

        [HttpGet("{id}")]
        public void Put(Guid id, Sala sala)
        {
            sala.Id = id;
             _salaRepository.Editar(sala);
        }

        [HttpGet("{id}")]
        public void Delete(Guid id)
        {
            _salaRepository.Deletar(id);
        }
    }
}
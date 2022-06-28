using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Data.Dtos.Cargos;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CargoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable Cargo([FromQuery] string nome)
        {
            List<Cargos> cargos = new List<Cargos>();
            cargos = _context.Cargos.ToList();

            if (string.IsNullOrEmpty(nome))
            {
                return cargos;
            }

            var query = from cargo in cargos
                        where cargo.Nome.ToLower() == nome.ToLower()
                        select cargo;

            cargos = query.ToList();

            return cargos;
        }

        [HttpGet("{id}")]
        public IActionResult Cargo(int id)
        {
            Cargos cargo = new Cargos();
            cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);

            if(cargo == null)
            {
                return NotFound();
            }

            ReadCargosDto cargoDto = _mapper.Map<ReadCargosDto>(cargo); 

            return Ok(cargoDto);
        }

        [HttpPost]
        public IActionResult Cargo([FromBody] CreateCargosDto cargoDto)
        {
            var cargo = _mapper.Map<Cargos>(cargoDto);

            _context.Cargos.Add(cargo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Cargo), new {Id = cargo.Id}, cargo);
        }

        [HttpPut("{id}")]
        public IActionResult Cargo(int id, [FromBody] CreateCargosDto cargoDto)
        {
            Cargos cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);

            if (cargo == null)
            {
                return NotFound();
            }

            try
            {
                cargo = _mapper.Map(cargoDto, cargo);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DelCargo(int id)
        {
            Cargos cargo = _context.Cargos.
                FirstOrDefault(cargo => cargo.Id == id);

            if(cargo == null)
            {
                return NotFound();
            }

            try
            {
                _context.Cargos.Remove(cargo);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message,
                    Mensagem = "Verifique os dados e tente novamente. O cargo já esta em uso por membros?"
                });
            }
            
            return NoContent();
        }

    }
}

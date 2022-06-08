using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private AppDbContext _context;

        public CargoController(AppDbContext context)
        {
            _context = context;
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
            cargo = _context.Cargos.Find(id);

            if(cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        [HttpPost]
        public IActionResult Cargo([FromBody] Cargos cargo)
        {
            _context.Cargos.Add(cargo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Cargo), new {Id = cargo.Id}, cargo);
        }

        [HttpPut("{id}")]
        public IActionResult Cargo(int id, [FromBody] Cargos newCargo)
        {
            Cargos cargo = new Cargos();
            cargo = _context.Cargos.Find(id);

            cargo.Nome = newCargo.Nome;
            cargo.Descricao = newCargo.Descricao;

            _context.SaveChanges();
            
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

            _context.Cargos.Remove(cargo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

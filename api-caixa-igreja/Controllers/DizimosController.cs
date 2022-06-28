using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Data.Dtos.Dizimos;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DizimosController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DizimosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Dizimos(CreateDizimosDto dizimoDto)
        {
            //if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                Dizimos dizimo = _mapper.Map<Dizimos>(dizimoDto);
                _context.Dizimos.Add(dizimo);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Dizimos), new { Id = dizimo.Id }, dizimo);

            }
            catch (Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult Dizimos([FromQuery] string periodo,[FromQuery] int idMembroDizimista)
        {
            List<Dizimos> dizimos = _context.Dizimos.ToList();

            if(! string.IsNullOrEmpty(periodo))
            {
                var query = (
                    from dizimo in dizimos
                    where dizimo.Periodo == periodo
                    select dizimo).ToList();

                dizimos = query;
            }

            if(idMembroDizimista > 0)
            {
                var membros = _context.Membros.ToList();
                var query = (
                     from dizimo in dizimos
                     join membro in membros 
                     on dizimo.IdMembroDizimista equals membro.Id
                     where membro.Id == idMembroDizimista
                     select dizimo).ToList();

                dizimos = query;
            }

            List<ReadDizimosDto> dizimoDto = _mapper.Map<List<ReadDizimosDto>>(dizimos);    

            return Ok(dizimoDto);
        }

        [HttpGet("{id}")]
        public IActionResult Dizimos(int id)
        {
            var dizimos = _context.Dizimos.FirstOrDefault(d => d.Id == id);

            if (dizimos == null)
            {
                return NotFound();
            }

            ReadDizimosDto dizimoDto = _mapper.Map<ReadDizimosDto>(dizimos);

            return Ok(dizimoDto);
        }

        [HttpPut("{id}")]
        public IActionResult Dizimos(int id, CreateDizimosDto dizimoDto)
        {
            Dizimos dizimo = _context.Dizimos.FirstOrDefault(of => of.Id == id);
            if (dizimo == null)
            {
                return NotFound();
            }

            try
            {
                dizimo = _mapper.Map(dizimoDto, dizimo);
                _context.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDizimos(int id)
        {
            Dizimos dizimo = _context.Dizimos.FirstOrDefault(of => of.Id == id);
            if (dizimo == null)
            {
                return NotFound();
            }

            _context.Dizimos.Remove(dizimo);
            _context.SaveChanges();

            return NoContent();
        }

    }
}

using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Data.Dtos.TipoOferta;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoOfertaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public TipoOfertaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public IActionResult TipoOferta(int id, [FromBody] CreateTipoOfertaDto tipoOfertaDto)
        {
            var tipoOferta = _context.TipoOferta.FirstOrDefault(t => t.Id == id);

            if(tipoOferta == null)
            {
                return NotFound();
            }

            try
            {
                tipoOferta = _mapper.Map(tipoOfertaDto, tipoOferta);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message,
                });
            }
        }

        [HttpPost]
        public IActionResult TipoOferta([FromBody] CreateTipoOfertaDto tipoOfertaDto)
        {
            try
            {
                var tipoOferta = _mapper.Map<TipoOferta>(tipoOfertaDto);

                _context.TipoOferta.Add(tipoOferta);
                _context.SaveChanges();

                return CreatedAtAction(nameof(TipoOferta), new { Id = tipoOferta.Id }, tipoOferta);
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult TipoOferta([FromQuery] string nome)
        {
            IList<TipoOferta> tipoOferta = _context.TipoOferta.ToList();

            if (! string.IsNullOrEmpty(nome)) 
            {
                var query = (from t in tipoOferta
                      where t.Nome == nome
                      select t).ToList();

                tipoOferta = query;
            }

            return Ok(tipoOferta);
        }

        [HttpGet("{id}")]
        public IActionResult TipoOferta(int id)
        {
            try
            {
                var tipoOferta = _context.TipoOferta.FirstOrDefault(t => t.Id == id);

                if(tipoOferta == null)
                {
                    return NotFound();
                }

                ReadTipoOfertaDto tipoOfertaDto = _mapper.Map<ReadTipoOfertaDto>(tipoOferta);

                return Ok(tipoOferta);
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoOferta(int id)
        {
            try
            {
                var tipoOferta = _context.TipoOferta.FirstOrDefault(t => t.Id == id);

                if(tipoOferta == null)
                {
                    return NotFound();
                }

                _context.Remove(tipoOferta);
                _context.SaveChanges();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }

        }
    }
}

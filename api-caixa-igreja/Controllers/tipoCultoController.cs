using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Data.Dtos.TipoCulto;
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
    public class TipoCultoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public TipoCultoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public IActionResult TipoCulto(int id, [FromBody] CreateTipoCultoDto tipoCultoDto)
        {
            var tipoCulto = _context.TipoCulto.FirstOrDefault(t => t.Id == id);

            if(tipoCulto == null)
            {
                return NotFound();
            }

            try
            {
                tipoCulto = _mapper.Map(tipoCultoDto, tipoCulto);
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
        public IActionResult TipoCulto([FromBody] CreateTipoCultoDto tipoCultoDto)
        {
            try
            {
                TipoCulto tipoCulto = _mapper.Map<TipoCulto>(tipoCultoDto);

                _context.TipoCulto.Add(tipoCulto);
                _context.SaveChanges();

                return Ok();
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
        public IActionResult TipoCulto([FromQuery] string nome)
        {
            IList<TipoCulto> tipoCulto = _context.TipoCulto.ToList();

            if (! string.IsNullOrEmpty(nome)) 
            {
                var query = (from t in tipoCulto
                      where t.Nome == nome
                      select t).ToList();

                tipoCulto = query;
            }

            return Ok(tipoCulto);
        }

        [HttpGet("{id}")]
        public IActionResult TipoCulto(int id)
        {
            try
            {
                var tipoCulto = _context.TipoCulto.FirstOrDefault(t => t.Id == id);

                if(tipoCulto == null)
                {
                    return NotFound();
                }

                ReadTipoCultoDto TipoCultoDto = _mapper.Map<ReadTipoCultoDto>(tipoCulto);

                return Ok(tipoCulto);
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
        public IActionResult DeleteTipoCulto(int id)
        {
            try
            {
                var tipoCulto = _context.TipoCulto.FirstOrDefault(t => t.Id == id);

                if(tipoCulto == null)
                {
                    return NotFound();
                }

                _context.Remove(tipoCulto);
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

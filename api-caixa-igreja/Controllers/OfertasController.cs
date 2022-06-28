using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using api_caixa_igreja.Models.Data.Dtos.Ofertas;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertasController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public OfertasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Ofertas([FromQuery] string dia, 
            [FromQuery] int IdtipoCulto, 
            [FromQuery] int IdtipoOferta,
            [FromQuery] int IdMembroMinistrante){

            List<Ofertas> ofertas = _context.Ofertas.ToList();
            if(ofertas == null)
            {
                return NoContent();
            }

            //INNER JOIN DE OFERTAS E MEMBRO
            if (IdMembroMinistrante > 0)
            {
                List<Membros> membros = _context.Membros.ToList();

                var query = (
                from oferta in ofertas
                join membro in membros
                on oferta.IdMembroMinistrante equals membro.Id
                where membro.Id == IdMembroMinistrante
                select oferta).ToList();

                ofertas = query;
            }

            //INNER JOIN DE OFERTAS E TIPO DE CULTO
            if (IdtipoCulto > 0)
            {
                List<TipoCulto> tipoCultos = _context.TipoCulto.ToList();

                var query = (
                from oferta in ofertas
                join tipoCulto in tipoCultos
                on oferta.IdTipoCulto equals tipoCulto.Id
                where tipoCulto.Id == IdtipoCulto
                select oferta).ToList();

                ofertas = query;
            }

            //INNER JOIN DE OFERTAS E TIPO DE OFERTA
            if (IdtipoOferta > 0)
            {
                List<TipoOferta> tipoOfertas = _context.TipoOferta.ToList();

                var query = (
                from oferta in ofertas
                join tipoOferta in tipoOfertas
                on oferta.IdTipoOferta equals tipoOferta.Id
                where tipoOferta.Id == IdtipoOferta
                select oferta).ToList();

                ofertas = query;
            }

            if (! string.IsNullOrWhiteSpace(dia))
            {
                var query = (
                from oferta in ofertas
                where (oferta.Dia).ToString("dd-MM-yyyy") == dia
                select oferta).ToList();

                ofertas = query;
            }

            List<ReadOfertasDto> ofertasDto = _mapper.Map<List<ReadOfertasDto>>(ofertas);   

            return Ok(ofertasDto);
        }


        [HttpGet("{id}")]
        public IActionResult Ofertas(int id)
        {
            Ofertas oferta = _context.Ofertas.Find(id);
            if (oferta == null)
            {
                return NotFound();
            }

            ReadOfertasDto ofertaDto = _mapper.Map<ReadOfertasDto>(oferta);

            return Ok(ofertaDto);
        }

        [HttpPost]
        public IActionResult Ofertas(CreateOfertasDto ofertaDto)
        {
            try
            {
                var oferta = _mapper.Map<Ofertas>(ofertaDto);
                _context.Ofertas.Add(oferta);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Ofertas), new { Id = oferta.Id }, oferta);
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Ofertas(int id, CreateOfertasDto ofertaDto)
        {
            Ofertas oferta = _context.Ofertas.FirstOrDefault(of => of.Id == id);
            if(oferta == null)
            {
                return NotFound();
            }

            try
            {
                oferta = _mapper.Map(ofertaDto, oferta);
                _context.SaveChanges();

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOfertas(int id)
        {
            Ofertas oferta = _context.Ofertas.FirstOrDefault(of => of.Id == id);
            if(oferta == null)
            {
                return NotFound();
            }

            _context.Ofertas.Remove(oferta);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

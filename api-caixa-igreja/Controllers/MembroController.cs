using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Data.Dtos.Membros;
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
    public class MembroController : ControllerBase  
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
         
        public MembroController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Membro([FromQuery] string nome)
        {
           List<Membros> membros = _context.Membros.ToList();   

            if (membros == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                return Ok(membros);
            }

            var query = from m in membros
                        where m.Nome.ToLower() == nome.ToLower()
                        select m;
            membros = query.ToList();

            return Ok(membros);          
        }

        [HttpGet("{id}")]
        public IActionResult Membro(int id)
        {
            Membros membro = _context.Membros.Find(id);
            if(membro == null)
            {
                return NotFound();
            }

            ReadMembrosDto membroDto = _mapper.Map<ReadMembrosDto>(membro);

            return Ok(membroDto);
        }

        [HttpPost]
        public IActionResult Membro(CreateMembrosDto membroDto)
        {
            var membro = _mapper.Map<Membros>(membroDto);

            try
            {
                _context.Add(membro);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Membro), new {Id = membro.Id }, membro);
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message,
                    Mensagem = "Verifique os dados e tente novamente"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Membro(int id, [FromBody] CreateMembrosDto membroDto)
        {
            Membros membro = _context.Membros.Find(id);
            if(membro == null)
            {
                return NotFound();
            }

            try
            {
                membro = _mapper.Map(membroDto, membro);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMembro(int id)
        {
            Membros membro = _context.Membros.FirstOrDefault(m => m.Id == id);
            if(membro == null) { 
                return NotFound();
            }

            _context.Membros.Remove(membro);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

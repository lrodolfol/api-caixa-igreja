using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

            return Ok(membro);
        }

        [HttpPost]
        public IActionResult Membro(Membros membro)
        {
            try
            {
                _context.Add(membro);
                _context.SaveChanges();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(new MessageException
                {
                    descricao = ex.Message,
                    mensagem = "Verifique os dados e tente novamente"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Membro(int id, [FromBody] MembrosUpdateCto membroAtualizado)
        {
            Membros membro = _context.Membros.Find(id);
            if(membro == null)
            {
                return NotFound();
            }

            _mapper.Map(membroAtualizado, membro);           
            _context.SaveChanges();

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
